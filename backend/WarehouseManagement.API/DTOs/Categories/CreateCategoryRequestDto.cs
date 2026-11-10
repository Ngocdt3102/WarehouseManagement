using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Categories;

public class CreateCategoryRequestDto
{
    [Required(ErrorMessage = "Tên danh mục là bắt buộc.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Tên danh mục phải từ 2-100 ký tự.")]
    public string Name { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Mô tả không vượt quá 500 ký tự.")]
    public string? Description { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Hình ảnh không hợp lệ.")]
    public int? ImageId { get; set; }

    // Dùng khi tạo danh mục con thuộc về một danh mục cha
    [Range(1, int.MaxValue, ErrorMessage = "ID Danh mục cha không hợp lệ.")]
    public int? ParentCategoryId { get; set; }
}
