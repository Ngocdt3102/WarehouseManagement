using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("Categories")]
public class CategoryModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên danh mục là bắt buộc.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Tên danh mục phải từ 2-100 ký tự.")]
    public string Name { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Mô tả không vượt quá 500 ký tự.")]
    public string? Description { get; set; }

    public int? ImageId { get; set; }
    public virtual File? Image { get; set; }

    public int? ParentCategoryId { get; set; }

    public bool IsActive { get; set; } = true;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public CategoryModel? ParentCategory { get; set; }
    public ICollection<CategoryModel> SubCategories { get; set; } = new List<CategoryModel>();
    public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
}