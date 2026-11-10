using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.Models;

public class PermissionModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Mã quyền là bắt buộc.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Mã quyền phải từ 5-100 ký tự.")]
    [RegularExpression(@"^[A-Z_]+$", ErrorMessage = "Mã quyền chỉ chứa chữ in hoa và dấu gạch dưới (VD: PRODUCT_CREATE).")]
    public string Code { get; set; } = null!;

    [Required(ErrorMessage = "Tên module là bắt buộc.")]
    [StringLength(50, ErrorMessage = "Tên module không vượt quá 50 ký tự.")]
    public string Module { get; set; } = null!; // Dùng để nhóm quyền trên UI (VD: INVENTORY, PRODUCT)

    [StringLength(200, ErrorMessage = "Mô tả không vượt quá 200 ký tự.")]
    public string? Description { get; set; }

    // Navigation Properties
    public ICollection<RolePermissionModel> RolePermissions { get; set; } = new List<RolePermissionModel>();
}