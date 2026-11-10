using WarehouseManagement.API.DTOs.GoodsIssues;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;
using WarehouseManagement.API.Services.Interfaces;

namespace WarehouseManagement.API.Services.Implementations;

public class GoodsIssueService : IGoodsIssueService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInventoryService _inventoryService;

    public GoodsIssueService(IUnitOfWork unitOfWork, IInventoryService inventoryService)
    {
        _unitOfWork = unitOfWork;
        _inventoryService = inventoryService;
    }

    public async Task<GoodsIssueResponseDto> CreateIssueAsync(CreateGoodsIssueRequestDto request, int employeeId)
    {
        // 1. MỞ GIAO DỊCH
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            // 2. Tạo mã phiếu xuất tự động (Giả lập hoặc viết hàm trong Repository)
            string newIssueCode = $"GI-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";

            // 3. Khởi tạo Entity Phiếu Xuất
            var issue = new GoodsIssue
            {
                IssueCode = newIssueCode,
                IssueDate = request.Date,
                CustomerId = request.CustomerId,
                WarehouseId = request.WarehouseId,
                EmployeeId = employeeId,
                Remarks = request.Remarks,
                Status = "COMPLETED", // Nếu có duyệt thì đổi thành PENDING
                CreatedAt = DateTime.UtcNow,
                Details = new List<GoodsIssueDetail>()
            };

            // 4. Xử lý từng dòng chi tiết & TRỪ TỒN KHO
            foreach (var detailDto in request.Details)
            {
                // Thêm chi tiết phiếu xuất
                // Ghi chú: Nếu Models của bạn chưa có trường BatchId cho GoodsIssueDetail, hãy thêm vào nhé!
                issue.Details.Add(new GoodsIssueDetail
                {
                    ProductId = detailDto.ProductId,
                    LocationId = detailDto.LocationId,
                    Quantity = detailDto.Quantity
                    // BatchId = detailDto.BatchId // Mở comment dòng này nếu Entity đã có trường BatchId
                });

                // GỌI INVENTORY SERVICE TRỪ TỒN KHO
                // NẾU KHÔNG ĐỦ HÀNG: Hàm này sẽ tự động ném ra InvalidOperationException
                await _inventoryService.RemoveStockAsync(
                    detailDto.ProductId,
                    request.WarehouseId,
                    detailDto.LocationId,
                    detailDto.Quantity
                );
            }

            // 5. Thêm Phiếu xuất
            await _unitOfWork.GoodsIssues.AddAsync(issue);

            // 6. Lưu toàn bộ thay đổi và Commit Giao dịch
            await _unitOfWork.CommitTransactionAsync();

            return await GetIssueByIdAsync(issue.Id)
                ?? throw new Exception("Tạo phiếu xuất thành công nhưng lỗi khi truy xuất kết quả.");
        }
        catch
        {
            // Nếu không đủ hàng (RemoveStockAsync ném Exception) hoặc có lỗi mạng,
            // HỦY BỎ toàn bộ giao dịch, đảm bảo Phiếu Xuất không được sinh ra.
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<GoodsIssueResponseDto?> GetIssueByIdAsync(int id)
    {
        var issue = await _unitOfWork.GoodsIssues.GetIssueWithDetailsAsync(id);
        if (issue == null) return null;

        var dto = new GoodsIssueResponseDto
        {
            Id = issue.Id,
            IssueCode = issue.IssueCode,
            Date = issue.IssueDate,
            CustomerId = issue.CustomerId,
            CustomerName = issue.Customer?.Name ?? "N/A",
            WarehouseId = issue.WarehouseId,
            WarehouseName = issue.Warehouse?.Name ?? "N/A",
            EmployeeId = issue.EmployeeId,
            EmployeeFullName = issue.Employee?.FullName ?? issue.Employee?.Username ?? "N/A",
            Remarks = issue.Remarks,
            Status = issue.Status ?? "COMPLETED",
            CreatedAt = issue.CreatedAt,
            UpdatedAt = issue.UpdatedAt,
            Details = new List<GoodsIssueDetailItemDto>()
        };

        if (issue.Details != null)
        {
            foreach (var d in issue.Details)
            {
                var detailDto = new GoodsIssueDetailItemDto
                {
                    Id = d.Id,
                    ProductId = d.ProductId,
                    ProductSKU = d.Product?.SKU ?? "N/A",
                    ProductName = d.Product?.Name ?? "N/A",
                    UnitName = d.Product?.Unit?.Name ?? "N/A",
                    LocationId = d.LocationId,
                    LocationCode = d.Location?.Code,
                    Quantity = d.Quantity
                    // BatchId = d.BatchId,
                    // BatchCode = d.Batch?.BatchCode
                };
                dto.Details.Add(detailDto);
            }
        }

        return dto;
    }
}