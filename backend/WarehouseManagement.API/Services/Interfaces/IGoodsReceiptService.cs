using WarehouseManagement.API.DTOs.GoodsReceipts;

namespace WarehouseManagement.API.Services.Interfaces;

public interface IGoodsReceiptService
{
    // Thêm tham số employeeId để truyền từ Controller xuống
    Task<GoodsReceiptResponseDto> CreateReceiptAsync(CreateGoodsReceiptRequestDto request, int employeeId);

    Task<GoodsReceiptResponseDto?> GetReceiptByIdAsync(int id);

    // Nâng cao (Tùy chọn cho tương lai): Lấy danh sách phiếu nhập
    // Task<IEnumerable<GoodsReceiptListDto>> GetReceiptsAsync(GoodsReceiptFilterDto filter);
}