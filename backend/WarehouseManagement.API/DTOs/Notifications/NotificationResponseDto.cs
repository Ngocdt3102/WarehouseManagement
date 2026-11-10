namespace WarehouseManagement.API.DTOs.Notifications;

public class NotificationResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Message { get; set; } = null!;
    public string Type { get; set; } = null!; // INFO, WARNING, ERROR, SUCCESS
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
}