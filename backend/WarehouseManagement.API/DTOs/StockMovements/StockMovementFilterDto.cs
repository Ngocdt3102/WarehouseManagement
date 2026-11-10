using System.ComponentModel.DataAnnotations;
using WarehouseManagement.API.DTOs.Common;
using WarehouseManagement.API.Enums;

namespace WarehouseManagement.API.DTOs.StockMovements;

public class StockMovementFilterDto : FilterDto, IValidatableObject
{
    [Range(1, int.MaxValue, ErrorMessage = "ID Sản phẩm không hợp lệ.")]
    public int? ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Kho không hợp lệ.")]
    public int? WarehouseId { get; set; }

    // Lọc theo loại biến động (IMPORT, EXPORT, TRANSFER_IN...)
    public StockMovementType? MovementType { get; set; }

    // Lọc theo khoảng thời gian
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }

    // Lọc theo nhân viên thực hiện (để đối soát)
    [Range(1, int.MaxValue, ErrorMessage = "ID Người dùng không hợp lệ.")]
    public int? UserId { get; set; }

    // Mã phiếu tham chiếu (vd: Nhập mã phiếu GR-001 để xem các biến động liên quan)
    [StringLength(50, ErrorMessage = "Loại tham chiếu không vượt quá 50 ký tự.")]
    public string? ReferenceType { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (FromDate.HasValue && ToDate.HasValue && FromDate > ToDate)
        {
            yield return new ValidationResult(
                "Từ ngày (FromDate) không được lớn hơn Đến ngày (ToDate).",
                new[] { nameof(FromDate), nameof(ToDate) }
            );
        }
    }
}
