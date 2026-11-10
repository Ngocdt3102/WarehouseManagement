using System.ComponentModel.DataAnnotations;
using WarehouseManagement.API.DTOs.Common;

namespace WarehouseManagement.API.DTOs.AuditLogs;

public class AuditLogFilterDto : FilterDto, IValidatableObject
{
    [Range(1, int.MaxValue, ErrorMessage = "ID Người dùng không hợp lệ.")]
    public int? UserId { get; set; }

    // Loại hành động: "CREATE", "UPDATE", "DELETE", "LOGIN"...
    [StringLength(50, ErrorMessage = "Action không vượt quá 50 ký tự.")]
    public string? Action { get; set; }

    // Tên bảng dữ liệu (vd: "Products", "GoodsReceipts")
    [StringLength(100, ErrorMessage = "TableName không vượt quá 100 ký tự.")]
    public string? TableName { get; set; }

    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }

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
