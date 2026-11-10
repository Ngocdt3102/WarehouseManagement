using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Stocktakes;

public class UpdateStocktakeCountDto
{
    [Required(ErrorMessage = "Sản phẩm là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Sản phẩm không hợp lệ.")]
    public int ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Vị trí không hợp lệ.")]
    public int? LocationId { get; set; }

    [Required(ErrorMessage = "Số lượng đếm thực tế là bắt buộc.")]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng đếm thực tế phải lớn hơn hoặc bằng 0.")]
    public int CountedQuantity { get; set; }

    [StringLength(250, ErrorMessage = "Lý do giải trình chênh lệch không vượt quá 250 ký tự.")]
    public string? Reason { get; set; }
}
