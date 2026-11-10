using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.StockTransfers;

public class CreateStockTransferRequestDto : IValidatableObject
{
    [Required(ErrorMessage = "Kho nguồn là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Kho nguồn không hợp lệ.")]
    public int SourceWarehouseId { get; set; }

    [Required(ErrorMessage = "Kho đích là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Kho đích không hợp lệ.")]
    public int DestinationWarehouseId { get; set; }

    [Required(ErrorMessage = "Ngày chuyển là bắt buộc.")]
    public DateTime Date { get; set; }

    [StringLength(500, ErrorMessage = "Ghi chú không vượt quá 500 ký tự.")]
    public string? Remarks { get; set; }

    [Required(ErrorMessage = "Danh sách sản phẩm không được để trống.")]
    [MinLength(1, ErrorMessage = "Phải có ít nhất 1 sản phẩm trong phiếu chuyển kho.")]
    public List<StockTransferDetailDto> Details { get; set; } = new List<StockTransferDetailDto>();

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
