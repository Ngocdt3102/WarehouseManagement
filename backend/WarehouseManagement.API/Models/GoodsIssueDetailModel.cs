using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("GoodsIssueDetails")]
public class GoodsIssueDetailModel
{
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int GoodsIssueId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Số lượng xuất phải lớn hơn 0.")]
    public int Quantity { get; set; }

    public int? LocationId { get; set; }
    public int? BatchId { get; set; }

    // Navigation Properties
    public GoodsIssueModel GoodsIssue { get; set; } = null!;
    public ProductModel Product { get; set; } = null!;
    public WarehouseLocationModel? Location { get; set; }
    public BatchModel? Batch { get; set; }
}