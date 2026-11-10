namespace WarehouseManagement.API.DTOs.Auth;

public class LoginResponseDto
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public int ExpiresIn { get; set; }

    // Thông tin cơ bản của User trả về sau khi login thành công
    public AuthUserDto User { get; set; } = null!;
}

// Class phụ trợ để nhóm dữ liệu User trả về trong LoginResponse
public class AuthUserDto
{
    public int Id { get; set; }
    public string EmployeeCode { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public int? AvatarId { get; set; }
    public string? AvatarUrl { get; set; }
    public List<string> Roles { get; set; } = new List<string>();
    public List<string> Permissions { get; set; } = new List<string>();
}