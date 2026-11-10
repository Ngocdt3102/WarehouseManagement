using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("Inventories")]
public class InventoryModel
{
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ID Sản phẩm không hợp lệ.")]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ID Kho không hợp lệ.")]
    public int WarehouseId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ID Vị trí không hợp lệ.")]
    public int LocationId { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho không được âm.")]
    public int Quantity { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng giữ chỗ không được âm.")]
    public int ReservedQuantity { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng khả dụng không được âm.")]
    public int AvailableQuantity { get; set; } // Quantity - ReservedQuantity

    [Required]
    public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public ProductModel Product { get; set; } = null!;
    public WarehouseModel Warehouse { get; set; } = null!;
    public WarehouseLocationModel Location { get; set; } = null!;
}