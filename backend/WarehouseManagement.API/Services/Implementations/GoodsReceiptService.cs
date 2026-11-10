using WarehouseManagement.API.DTOs.GoodsReceipts;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;
using WarehouseManagement.API.Services.Interfaces;

namespace WarehouseManagement.API.Services.Implementations;

public class GoodsReceiptService : IGoodsReceiptService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInventoryService _inventoryService;

    public GoodsReceiptService(IUnitOfWork unitOfWork, IInventoryService inventoryService)
    {
        _unitOfWork = unitOfWork;
        _inventoryService = inventoryService;
    }

    public async Task<GoodsReceiptResponseDto> CreateReceiptAsync(CreateGoodsReceiptRequestDto request, int employeeId)
    {
        // 1. MỞ GIAO DỊCH
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            // 2. Tạo mã phiếu nhập tự động
            string newReceiptCode = await _unitOfWork.GoodsReceipts.GenerateNewReceiptCodeAsync();

            // 3. Khởi tạo Entity Phiếu Nhập
            var receipt = new GoodsReceipt
            {
                ReceiptCode = newReceiptCode,
                ReceiptDate = request.Date,
                SupplierId = request.SupplierId,
                WarehouseId = request.WarehouseId,
                EmployeeId = employeeId, // Lấy từ tham số (truyền từ Token)
                Remarks = request.Remarks,
                Status = "COMPLETED", // Giả định nhập kho thành công ngay. Nếu có quy trình duyệt, để là PENDING.
                CreatedAt = DateTime.UtcNow,
                Details = new List<GoodsReceiptDetail>()
            };

            // 4. Xử lý từng dòng chi tiết
            foreach (var detailDto in request.Details)
            {
                // XỬ LÝ LÔ HÀNG (BATCH) NẾU CÓ
                int? batchId = null;
                if (!string.IsNullOrEmpty(detailDto.BatchCode))
                {
                    // Tạm thời dùng hàm Get All rồi lọc, thực tế nên viết hàm FindByCode trong BatchRepository
                    var existingBatches = await _unitOfWork.Batches.GetAllAsync();
                    var currentBatch = existingBatches.FirstOrDefault(b => b.BatchCode == detailDto.BatchCode && b.ProductId == detailDto.ProductId);

                    if (currentBatch == null)
                    {
                        currentBatch = new Batch
                        {
                            BatchCode = detailDto.BatchCode,
                            ProductId = detailDto.ProductId,
                            ExpiryDate = detailDto.ExpiryDate,
                            ManufactureDate = DateTime.UtcNow, // Có thể yêu cầu FE gửi thêm nếu cần
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow
                        };
                        await _unitOfWork.Batches.AddAsync(currentBatch);

                        // Cần Save để lấy ID của Batch (tuy Save nhưng vẫn nằm trong Transaction chung)
                        await _unitOfWork.SaveChangesAsync();
                    }
                    batchId = currentBatch.Id;
                }

                // Thêm chi tiết vào phiếu nhập (Lưu ý: Entity GoodsReceiptDetail của bạn có thể cần thêm trường BatchId nếu muốn lưu Lô theo từng dòng)
                receipt.Details.Add(new GoodsReceiptDetail
                {
                    ProductId = detailDto.ProductId,
                    LocationId = detailDto.LocationId,
                    Quantity = detailDto.Quantity,
                    UnitPrice = detailDto.UnitPrice
                    // BatchId = batchId // (Bỏ comment nếu Entity GoodsReceiptDetail có trường BatchId)
                });

                // CỘNG TỒN KHO
                await _inventoryService.AddStockAsync(
                    detailDto.ProductId,
                    request.WarehouseId,
                    detailDto.LocationId,
                    detailDto.Quantity
                );
            }

            // Thêm Phiếu nhập
            await _unitOfWork.GoodsReceipts.AddAsync(receipt);

            // 5. LƯU TẤT CẢ VÀ COMMIT
            await _unitOfWork.CommitTransactionAsync();

            // 6. Trả về kết quả
            return await GetReceiptByIdAsync(receipt.Id)
                ?? throw new Exception("Tạo phiếu thành công nhưng lỗi khi truy xuất kết quả.");
        }
        catch
        {
            // Bắt lỗi và Rollback nếu có bất cứ ngoại lệ nào xảy ra
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<GoodsReceiptResponseDto?> GetReceiptByIdAsync(int id)
    {
        var receipt = await _unitOfWork.GoodsReceipts.GetReceiptWithDetailsAsync(id);
        if (receipt == null) return null;

        var dto = new GoodsReceiptResponseDto
        {
            Id = receipt.Id,
            ReceiptCode = receipt.ReceiptCode,
            Date = receipt.ReceiptDate,
            SupplierId = receipt.SupplierId,
            SupplierName = receipt.Supplier?.Name ?? "N/A",
            WarehouseId = receipt.WarehouseId,
            WarehouseName = receipt.Warehouse?.Name ?? "N/A",
            EmployeeId = receipt.EmployeeId,
            EmployeeFullName = receipt.Employee?.FullName ?? receipt.Employee?.Username ?? "N/A",
            Remarks = receipt.Remarks,
            Status = "COMPLETED", // Tạm hardcode, bạn có thể thêm trường Status vào Entity GoodsReceipt nếu cần
            CreatedAt = receipt.CreatedAt,
            TotalAmount = 0, // Sẽ tính ở vòng lặp bên dưới
            Details = new List<GoodsReceiptDetailItemDto>()
        };

        decimal totalAmount = 0;
        if (receipt.Details != null)
        {
            foreach (var d in receipt.Details)
            {
                var detailDto = new GoodsReceiptDetailItemDto
                {
                    Id = d.Id,
                    ProductId = d.ProductId,
                    ProductSKU = d.Product?.SKU ?? "N/A",
                    ProductName = d.Product?.Name ?? "N/A",
                    UnitName = d.Product?.Unit?.Name ?? "N/A",
                    LocationId = d.LocationId,
                    LocationCode = d.Location?.Code,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice
                    // BatchCode & ExpiryDate: Lấy từ bảng Batch nếu có liên kết
                };
                totalAmount += detailDto.LineTotal;
                dto.Details.Add(detailDto);
            }
        }

        dto.TotalAmount = totalAmount;

        return dto;
    }
}