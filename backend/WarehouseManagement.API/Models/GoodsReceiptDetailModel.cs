using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("GoodsReceiptDetails")]
public class GoodsReceiptDetailModel
{
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int GoodsReceiptId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập phải lớn hơn 0.")]
    public int Quantity { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Đơn giá không được âm.")]
    public decimal UnitPrice { get; set; }

    public int? BatchId { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public int? LocationId { get; set; }

    // Navigation Properties
    public GoodsReceiptModel GoodsReceipt { get; set; } = null!;
    public ProductModel Product { get; set; } = null!;
    public WarehouseLocationModel? Location { get; set; }
    public BatchModel? Batch { get; set; }
}