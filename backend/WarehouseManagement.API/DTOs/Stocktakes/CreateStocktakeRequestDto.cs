using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Stocktakes;

public class CreateStocktakeRequestDto
{
    [Required(ErrorMessage = "Kho kiểm kê là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Kho không hợp lệ.")]
    public int WarehouseId { get; set; }

    [StringLength(500, ErrorMessage = "Ghi chú không vượt quá 500 ký tự.")]
    public string? Remarks { get; set; }

    // Tùy chọn: Chỉ kiểm kê một số danh mục nhất định
    public List<int>? CategoryIds { get; set; }
}
