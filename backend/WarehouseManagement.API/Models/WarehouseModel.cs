using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using WarehouseManagement.API.Enums;

namespace WarehouseManagement.API.Models;

[Table("Warehouses")]
public class WarehouseModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Mã kho là bắt buộc.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Mã kho phải từ 3-20 ký tự.")]
    [RegularExpression(@"^[A-Z0-9\-_]+$", ErrorMessage = "Mã kho chỉ chứa chữ in hoa, số, dấu gạch ngang/dưới.")]
    public string Code { get; set; } = null!;

    [Required(ErrorMessage = "Tên kho là bắt buộc.")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Tên kho phải từ 2-150 ký tự.")]
    public string Name { get; set; } = null!;

    [StringLength(250, ErrorMessage = "Địa chỉ không vượt quá 250 ký tự.")]
    public string? Address { get; set; }

    public int? ManagerId { get; set; }

    [Required]
    public WarehouseStatus Status { get; set; } = WarehouseStatus.ACTIVE;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public UserModel? Manager { get; set; }
    public ICollection<WarehouseLocationModel> Locations { get; set; } = new List<WarehouseLocationModel>();
    public ICollection<InventoryModel> Inventories { get; set; } = new List<InventoryModel>();
}