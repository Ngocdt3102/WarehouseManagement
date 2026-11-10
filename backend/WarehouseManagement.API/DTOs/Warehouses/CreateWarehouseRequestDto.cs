using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Warehouses;

public class CreateWarehouseRequestDto
{
    [Required(ErrorMessage = "Mã kho là bắt buộc.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Mã kho phải từ 3-20 ký tự.")]
    [RegularExpression(@"^[A-Z0-9\-_]+$", ErrorMessage = "Mã kho chỉ chứa chữ in hoa, số, dấu gạch ngang/dưới.")]
    public string Code { get; set; } = null!;

    [Required(ErrorMessage = "Tên kho là bắt buộc.")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Tên kho phải từ 2-150 ký tự.")]
    public string Name { get; set; } = null!;

    [StringLength(250, ErrorMessage = "Địa chỉ không vượt quá 250 ký tự.")]
    public string? Address { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Thủ kho không hợp lệ.")]
    public int? ManagerId { get; set; }
}
