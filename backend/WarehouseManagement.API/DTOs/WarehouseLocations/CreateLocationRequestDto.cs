using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.WarehouseLocations;

public class CreateLocationRequestDto
{
    [Required(ErrorMessage = "Mã vị trí là bắt buộc.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Mã vị trí phải từ 2-50 ký tự.")]
    [RegularExpression(@"^[a-zA-Z0-9\-_]+$", ErrorMessage = "Mã vị trí không được chứa khoảng trắng (VD: W1-Z1-R1).")]
    public string Code { get; set; } = null!;

    [Required(ErrorMessage = "ID Kho là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Kho không hợp lệ.")]
    public int WarehouseId { get; set; }

    [StringLength(50, ErrorMessage = "Zone không vượt quá 50 ký tự.")]
    public string? Zone { get; set; }

    [StringLength(50, ErrorMessage = "Rack không vượt quá 50 ký tự.")]
    public string? Rack { get; set; }

    [StringLength(50, ErrorMessage = "Shelf không vượt quá 50 ký tự.")]
    public string? Shelf { get; set; }

    [StringLength(50, ErrorMessage = "Bin không vượt quá 50 ký tự.")]
    public string? Bin { get; set; }
}