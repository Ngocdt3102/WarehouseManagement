using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagement.API.Enums;

namespace WarehouseManagement.API.Models;

[Table("Stocktakes")]
public class StocktakeModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [RegularExpression(@"^TK-[A-Z0-9]+$", ErrorMessage = "Mã kiểm kê phải có tiền tố TK- và không chứa khoảng trắng.")]
    public string StocktakeCode { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue)]
    public int WarehouseId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int CreatedById { get; set; }

    public int? ApprovedById { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Required]
    public StocktakeStatus Status { get; set; } = StocktakeStatus.PENDING;

    [StringLength(500)]
    public string? Remarks { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public WarehouseModel Warehouse { get; set; } = null!;
    public UserModel CreatedBy { get; set; } = null!;
    public UserModel? ApprovedBy { get; set; }
    public ICollection<StocktakeDetailModel> Details { get; set; } = new List<StocktakeDetailModel>();
}