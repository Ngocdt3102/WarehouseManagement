using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Units;

public class UpdateUnitRequestDto
{
    [Required(ErrorMessage = "Tên đơn vị tính là bắt buộc.")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Tên đơn vị tính phải từ 1-50 ký tự.")]
    public string Name { get; set; } = null!;

    [StringLength(200, ErrorMessage = "Mô tả không vượt quá 200 ký tự.")]
    public string? Description { get; set; }

    public bool IsActive { get; set; }
}