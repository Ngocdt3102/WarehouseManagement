using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("Units")]
public class UnitModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên đơn vị tính là bắt buộc.")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Tên đơn vị tính phải từ 1-50 ký tự.")]
    public string Name { get; set; } = null!;

    [StringLength(200, ErrorMessage = "Mô tả không vượt quá 200 ký tự.")]
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
}