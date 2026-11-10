using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Products;

public class CreateProductRequestDto : IValidatableObject
{
    [Required(ErrorMessage = "Mã SKU là bắt buộc.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Mã SKU phải từ 3-50 ký tự.")]
    [RegularExpression(@"^[A-Z0-9\-_]+$", ErrorMessage = "SKU chỉ chứa chữ in hoa, số, dấu gạch ngang/dưới.")]
    public string SKU { get; set; } = null!;

    [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Tên sản phẩm phải từ 2-200 ký tự.")]
    public string Name { get; set; } = null!;

    [StringLength(1000, ErrorMessage = "Mô tả không vượt quá 1000 ký tự.")]
    public string? Description { get; set; }

    [StringLength(100, ErrorMessage = "Tên thương hiệu không vượt quá 100 ký tự.")]
    public string? Brand { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Hình ảnh không hợp lệ.")]
    public int? ImageId { get; set; }

    [Required(ErrorMessage = "Danh mục là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID danh mục không hợp lệ.")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Đơn vị tính là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID đơn vị tính không hợp lệ.")]
    public int UnitId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Nhà cung cấp không hợp lệ.")]
    public int? SupplierId { get; set; }

    [StringLength(100, ErrorMessage = "Barcode không vượt quá 100 ký tự.")]
    public string? Barcode { get; set; }

    [Required(ErrorMessage = "Tồn kho tối thiểu là bắt buộc.")]
    [Range(0, int.MaxValue, ErrorMessage = "Tồn kho tối thiểu phải >= 0.")]
    public int MinStock { get; set; }

    [Required(ErrorMessage = "Tồn kho tối đa là bắt buộc.")]
    [Range(0, int.MaxValue, ErrorMessage = "Tồn kho tối đa phải >= 0.")]
    public int MaxStock { get; set; }

    [Required(ErrorMessage = "Trọng lượng là bắt buộc.")]
    [Range(0, double.MaxValue, ErrorMessage = "Trọng lượng phải lớn hơn hoặc bằng 0.")]
    public double Weight { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (MaxStock < MinStock)
        {
            yield return new ValidationResult(
                "Tồn kho tối đa (MaxStock) phải lớn hơn hoặc bằng tồn kho tối thiểu (MinStock).",
                new[] { nameof(MaxStock) }
            );
        }
    }
}
