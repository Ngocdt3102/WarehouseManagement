using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagement.API.Enums;

namespace WarehouseManagement.API.Models;

[Table("Notifications")]
public class NotificationModel
{
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }

    [Required]
    public NotificationType Type { get; set; } // LOW_STOCK, PENDING_APPROVAL...

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(1000)]
    public string Message { get; set; } = null!;

    public bool IsRead { get; set; } = false;

    public string? ReferenceLink { get; set; } // Link điều hướng trên UI

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public UserModel User { get; set; } = null!;
}