using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Roles;

public class AssignPermissionsRequestDto
{
    [Required(ErrorMessage = "Danh sách quyền không được để trống null.")]
    [MinLength(1, ErrorMessage = "Phải chọn ít nhất 1 quyền.")]
    public List<int> PermissionIds { get; set; } = new List<int>();
}
