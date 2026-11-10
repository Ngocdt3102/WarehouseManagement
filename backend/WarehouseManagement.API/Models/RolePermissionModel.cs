using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.Models;

public class RolePermissionModel
{
    [Required(ErrorMessage = "RoleId là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "RoleId không hợp lệ.")]
    public int RoleId { get; set; }

    [Required(ErrorMessage = "PermissionId là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "PermissionId không hợp lệ.")]
    public int PermissionId { get; set; }

    [Required]
    public DateTime GrantedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public RoleModel Role { get; set; } = null!;
    public PermissionModel Permission { get; set; } = null!;
}