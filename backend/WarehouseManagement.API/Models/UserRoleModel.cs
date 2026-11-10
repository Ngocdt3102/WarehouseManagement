using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.Models;

public class UserRoleModel
{
    [Required(ErrorMessage = "UserId là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "UserId không hợp lệ.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "RoleId là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "RoleId không hợp lệ.")]
    public int RoleId { get; set; }

    [Required]
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public UserModel User { get; set; } = null!;
    public RoleModel Role { get; set; } = null!;
}