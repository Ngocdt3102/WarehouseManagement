using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Users;

public class ResetPasswordRequestDto
{
    [Required(ErrorMessage = "Mật khẩu mới là bắt buộc.")]
    [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu mới phải từ 6-50 ký tự.")]
    public string NewPassword { get; set; } = null!;

    [Required(ErrorMessage = "Xác nhận mật khẩu mới là bắt buộc.")]
    [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
    public string ConfirmNewPassword { get; set; } = null!;
}