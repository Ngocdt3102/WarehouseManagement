using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.GoodsReceipts;

public class GoodsReceiptDetailDto
{
    [Required(ErrorMessage = "Sản phẩm là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Sản phẩm không hợp lệ.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Số lượng nhập là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập phải lớn hơn 0.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Đơn giá là bắt buộc.")]
    [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "Đơn giá không được âm.")]
    public decimal UnitPrice { get; set; }

    // Vị trí lưu trữ dự kiến (có thể gán sau trong bước cất hàng - putaway)
    [Range(1, int.MaxValue, ErrorMessage = "ID Vị trí không hợp lệ.")]
    public int? LocationId { get; set; }

    // Thông tin lô hàng (nếu sản phẩm có quản lý theo lô)
    [StringLength(50, ErrorMessage = "Mã lô không vượt quá 50 ký tự.")]
    [RegularExpression(@"^[A-Z0-9\-_]+$", ErrorMessage = "Mã lô chỉ chứa chữ in hoa, số, dấu gạch ngang/dưới.")]
    public string? BatchCode { get; set; }

    public DateTime? ExpiryDate { get; set; }
}
