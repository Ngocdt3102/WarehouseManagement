using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.GoodsReceipts;

public class CreateGoodsReceiptRequestDto
{
    [Required(ErrorMessage = "Nhà cung cấp là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Nhà cung cấp không hợp lệ.")]
    public int SupplierId { get; set; }

    [Required(ErrorMessage = "Kho nhập là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Kho không hợp lệ.")]
    public int WarehouseId { get; set; }

    [Required(ErrorMessage = "Ngày nhập là bắt buộc.")]
    public DateTime Date { get; set; }

    [StringLength(500, ErrorMessage = "Ghi chú không vượt quá 500 ký tự.")]
    public string? Remarks { get; set; }

    [Required(ErrorMessage = "Danh sách sản phẩm không được để trống.")]
    [MinLength(1, ErrorMessage = "Phải có ít nhất 1 sản phẩm trong phiếu nhập.")]
    public List<GoodsReceiptDetailDto> Details { get; set; } = new List<GoodsReceiptDetailDto>();

    // Lưu ý: EmployeeId (Người lập phiếu) sẽ được hệ thống tự động lấy từ Token (Claims) ở tầng Controller,
    // do đó không cần yêu cầu Frontend gửi lên để đảm bảo tính bảo mật.
}