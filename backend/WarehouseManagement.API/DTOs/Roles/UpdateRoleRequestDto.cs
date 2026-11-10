using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Roles;

public class UpdateRoleRequestDto
{
    [Required(ErrorMessage = "Tên Role là bắt buộc.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên Role phải từ 3-50 ký tự.")]
    [RegularExpression(@"^[A-Z_]+$", ErrorMessage = "Tên Role chỉ chứa chữ in hoa và dấu gạch dưới.")]
    public string Name { get; set; } = null!;

    [StringLength(200, ErrorMessage = "Mô tả không vượt quá 200 ký tự.")]
    public string? Description { get; set; }

    public bool IsActive { get; set; }
}