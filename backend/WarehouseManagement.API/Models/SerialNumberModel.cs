using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("SerialNumbers")]
public class SerialNumberModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Mã Serial không vượt quá 100 ký tự.")]
    public string SerialCode { get; set; } = null!; // Unique

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ID Sản phẩm không hợp lệ.")]
    public int ProductId { get; set; }

    public int? BatchId { get; set; }
    public int? GoodsReceiptDetailId { get; set; }
    public int? GoodsIssueDetailId { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Trạng thái Serial không vượt quá 50 ký tự.")]
    public string Status { get; set; } = "IN_STOCK"; // IN_STOCK, RESERVED, EXPORTED, RETURNED, DAMAGED

    // Navigation Properties
    public ProductModel Product { get; set; } = null!;
    public BatchModel? Batch { get; set; }
    public GoodsReceiptDetailModel? GoodsReceiptDetail { get; set; }
    public GoodsIssueDetailModel? GoodsIssueDetail { get; set; }
}
