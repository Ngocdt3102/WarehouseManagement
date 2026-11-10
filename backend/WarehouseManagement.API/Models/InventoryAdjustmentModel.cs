using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagement.API.Enums;

namespace WarehouseManagement.API.Models;

[Table("InventoryAdjustments")]
public class InventoryAdjustmentModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [RegularExpression(@"^AJ-[A-Z0-9]+$", ErrorMessage = "Mã điều chỉnh phải có tiền tố AJ- và không chứa khoảng trắng.")]
    public string AdjustmentCode { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue)]
    public int WarehouseId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int CreatedById { get; set; }

    public int? ApprovedById { get; set; }

    [Required]
    public DateTime AdjustmentDate { get; set; }

    [Required]
    public AdjustmentStatus Status { get; set; } = AdjustmentStatus.PENDING;

    [Required(ErrorMessage = "Lý do điều chỉnh là bắt buộc.")]
    [StringLength(500)]
    public string Reason { get; set; } = null!;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public WarehouseModel Warehouse { get; set; } = null!;
    public UserModel CreatedBy { get; set; } = null!;
    public UserModel? ApprovedBy { get; set; }
    public ICollection<InventoryAdjustmentDetailModel> Details { get; set; } = new List<InventoryAdjustmentDetailModel>();
}