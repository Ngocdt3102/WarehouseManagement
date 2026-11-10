namespace WarehouseManagement.API.DTOs.Users;

public class UserResponseDto
{
    public int Id { get; set; }
    public string EmployeeCode { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? AvatarId { get; set; }
    public string? AvatarUrl { get; set; }
    public bool IsActive { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Trả về danh sách tên Role để UI dễ hiển thị (vd: ["ADMIN", "WAREHOUSE_MANAGER"])
    public List<string> Roles { get; set; } = new List<string>();
}