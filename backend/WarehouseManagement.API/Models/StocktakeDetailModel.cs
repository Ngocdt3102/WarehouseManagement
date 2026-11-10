using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("StocktakeDetails")]
public class StocktakeDetailModel
{
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int StocktakeId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int LocationId { get; set; }

    public int? BatchId { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int SystemQuantity { get; set; }

    public int? ActualQuantity { get; set; } // Sẽ được cập nhật khi nhân viên đếm xong

    public int? DifferenceQuantity { get; set; } // Actual - System

    [StringLength(250)]
    public string? Reason { get; set; } // Giải trình chênh lệch

    // Navigation Properties
    public StocktakeModel Stocktake { get; set; } = null!;
    public ProductModel Product { get; set; } = null!;
    public WarehouseLocationModel Location { get; set; } = null!;
    public BatchModel? Batch { get; set; }
}