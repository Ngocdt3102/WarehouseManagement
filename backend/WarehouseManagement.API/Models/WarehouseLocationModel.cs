using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("WarehouseLocations")]
public class WarehouseLocationModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Mã vị trí là bắt buộc.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Mã vị trí phải từ 2-50 ký tự.")]
    [RegularExpression(@"^[a-zA-Z0-9\-_]+$", ErrorMessage = "Mã vị trí không được chứa khoảng trắng.")]
    public string Code { get; set; } = null!; // Ví dụ: W1-Z1-R1

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

    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public WarehouseModel Warehouse { get; set; } = null!;
    public ICollection<InventoryModel> Inventories { get; set; } = new List<InventoryModel>();
}