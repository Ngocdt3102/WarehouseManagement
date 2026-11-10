using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.Models;

public class RoleModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên Role là bắt buộc.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên Role phải từ 3-50 ký tự.")]
    [RegularExpression(@"^[A-Z_]+$", ErrorMessage = "Tên Role chỉ chứa chữ in hoa và dấu gạch dưới (VD: ADMIN, WAREHOUSE_MANAGER).")]
    public string Name { get; set; } = null!;

    [StringLength(200, ErrorMessage = "Mô tả không vượt quá 200 ký tự.")]
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public ICollection<UserRoleModel> UserRoles { get; set; } = new List<UserRoleModel>();
    public ICollection<RolePermissionModel> RolePermissions { get; set; } = new List<RolePermissionModel>();
}