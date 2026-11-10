using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Auth;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Username là bắt buộc.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username phải từ 3-50 ký tự.")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
    [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6-50 ký tự.")]
    public string Password { get; set; } = null!;
}
