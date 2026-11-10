using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("Batches")]
public class BatchModel : IValidatableObject
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string BatchCode { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int InitialQuantity { get; set; }

    public DateTime? ManufactureDate { get; set; }
    public DateTime? ExpiryDate { get; set; }

    public bool IsActive { get; set; } = true;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public ProductModel Product { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ManufactureDate.HasValue && ExpiryDate.HasValue && ExpiryDate <= ManufactureDate)
        {
            yield return new ValidationResult(
                "Hạn sử dụng (ExpiryDate) phải sau ngày sản xuất (ManufactureDate).",
                new[] { nameof(ExpiryDate) }
            );
        }
    }
}
