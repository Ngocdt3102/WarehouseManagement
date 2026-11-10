using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("InventoryAdjustmentDetails")]
public class InventoryAdjustmentDetailModel
{
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int InventoryAdjustmentId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int LocationId { get; set; }

    public int? BatchId { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng trước điều chỉnh phải >= 0.")]
    public int BeforeQuantity { get; set; }

    [Required]
    public int AdjustmentQuantity { get; set; } // Có thể âm (giảm tồn) hoặc dương (tăng tồn)

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng sau điều chỉnh phải >= 0.")]
    public int AfterQuantity { get; set; }

    // Navigation Properties
    public InventoryAdjustmentModel InventoryAdjustment { get; set; } = null!;
    public ProductModel Product { get; set; } = null!;
    public WarehouseLocationModel Location { get; set; } = null!;
    public BatchModel? Batch { get; set; }
}