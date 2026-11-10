using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("AuditLogs")]
public class AuditLogModel
{
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Action không vượt quá 50 ký tự.")]
    public string Action { get; set; } = null!; // Ví dụ: CREATE, UPDATE, DELETE

    [Required]
    [StringLength(100, ErrorMessage = "TableName không vượt quá 100 ký tự.")]
    public string TableName { get; set; } = null!;

    [Required]
    [StringLength(50, ErrorMessage = "RecordId không vượt quá 50 ký tự.")]
    public string RecordId { get; set; } = null!;

    public string? OldValues { get; set; } // Lưu JSON
    public string? NewValues { get; set; }  // Lưu JSON

    [StringLength(50, ErrorMessage = "IpAddress không vượt quá 50 ký tự.")]
    public string? IpAddress { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public UserModel User { get; set; } = null!;
}
