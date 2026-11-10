using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Notifications;

public class MarkNotificationReadDto
{
    [Required(ErrorMessage = "Danh sách ID thông báo là bắt buộc.")]
    [MinLength(1, ErrorMessage = "Phải có ít nhất 1 ID thông báo.")]
    public List<int> NotificationIds { get; set; } = new();
}
