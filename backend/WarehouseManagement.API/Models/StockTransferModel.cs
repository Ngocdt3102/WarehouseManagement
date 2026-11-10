using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagement.API.Enums;

namespace WarehouseManagement.API.Models;

[Table("StockTransfers")]
public class StockTransferModel : IValidatableObject
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [RegularExpression(@"^ST-[A-Z0-9]+$", ErrorMessage = "Mã phiếu chuyển phải có tiền tố ST- và không chứa khoảng trắng.")]
    public string TransferCode { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue)]
    public int SourceWarehouseId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int DestinationWarehouseId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int CreatedById { get; set; }

    public int? ApprovedById { get; set; }

    [Required]
    public DateTime TransferDate { get; set; }

    [Required]
    public StockTransferStatus Status { get; set; } = StockTransferStatus.PENDING;

    [StringLength(500)]
    public string? Reason { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public WarehouseModel SourceWarehouse { get; set; } = null!;
    public WarehouseModel DestinationWarehouse { get; set; } = null!;
    public UserModel CreatedBy { get; set; } = null!;
    public UserModel? ApprovedBy { get; set; }
    public ICollection<StockTransferDetailModel> Details { get; set; } = new List<StockTransferDetailModel>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (SourceWarehouseId == DestinationWarehouseId)
        {
            yield return new ValidationResult(
                "Kho đích phải khác kho nguồn.",
                new[] { nameof(DestinationWarehouseId) }
            );
        }
    }
}
