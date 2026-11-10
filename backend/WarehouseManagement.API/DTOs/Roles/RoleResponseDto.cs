namespace WarehouseManagement.API.DTOs.Roles;

public class RoleResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Danh sách mã quyền (Code) thuộc về Role này (vd: ["USER_VIEW", "PRODUCT_CREATE"])
    public List<string> Permissions { get; set; } = new List<string>();
}