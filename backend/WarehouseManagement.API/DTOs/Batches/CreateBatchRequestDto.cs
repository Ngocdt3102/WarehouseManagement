using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Batches;

public class CreateBatchRequestDto : IValidatableObject
{
    [Required(ErrorMessage = "Mã lô hàng là bắt buộc.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Mã lô hàng phải từ 2-50 ký tự.")]
    [RegularExpression(@"^[A-Z0-9\-_]+$", ErrorMessage = "Mã lô chỉ chứa chữ in hoa, số, dấu gạch ngang/dưới.")]
    public string BatchCode { get; set; } = null!;

    [Required(ErrorMessage = "Sản phẩm là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Sản phẩm không hợp lệ.")]
    public int ProductId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Số lượng ban đầu phải lớn hơn hoặc bằng 0.")]
    public int InitialQuantity { get; set; } = 0;

    public DateTime? ManufactureDate { get; set; }
    public DateTime? ExpiryDate { get; set; }

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
