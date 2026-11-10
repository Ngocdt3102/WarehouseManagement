namespace WarehouseManagement.API.DTOs.AuditLogs;

public class AuditLogResponseDto
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public string UserFullName { get; set; } = null!;

    public string Action { get; set; } = null!;
    public string TableName { get; set; } = null!;
    public string RecordId { get; set; } = null!;

    // Lưu trữ dưới dạng chuỗi JSON
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }

    public string IpAddress { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}