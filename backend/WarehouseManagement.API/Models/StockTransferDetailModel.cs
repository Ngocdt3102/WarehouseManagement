using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("StockTransferDetails")]
public class StockTransferDetailModel
{
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int StockTransferId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Số lượng chuyển phải lớn hơn 0.")]
    public int TransferQuantity { get; set; }

    public int? SourceLocationId { get; set; }
    public int? DestinationLocationId { get; set; }
    public int? BatchId { get; set; }

    // Navigation Properties
    public StockTransferModel StockTransfer { get; set; } = null!;
    public ProductModel Product { get; set; } = null!;
    public WarehouseLocationModel? SourceLocation { get; set; }
    public WarehouseLocationModel? DestinationLocation { get; set; }
    public BatchModel? Batch { get; set; }
}