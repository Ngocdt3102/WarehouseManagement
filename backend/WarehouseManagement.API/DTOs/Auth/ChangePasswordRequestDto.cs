using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Auth;

public class ChangePasswordRequestDto : IValidatableObject
{
    [Required(ErrorMessage = "Mật khẩu cũ là bắt buộc.")]
    public string OldPassword { get; set; } = null!;

    [Required(ErrorMessage = "Mật khẩu mới là bắt buộc.")]
    [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu mới phải từ 6-50 ký tự.")]
    public string NewPassword { get; set; } = null!;

    [Required(ErrorMessage = "Xác nhận mật khẩu mới là bắt buộc.")]
    [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp với mật khẩu mới.")]
    public string ConfirmNewPassword { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(OldPassword) && !string.IsNullOrEmpty(NewPassword) && OldPassword == NewPassword)
        {
            yield return new ValidationResult(
                "Mật khẩu mới không được trùng với mật khẩu cũ.",
                new[] { nameof(NewPassword) }
            );
        }
    }
}
