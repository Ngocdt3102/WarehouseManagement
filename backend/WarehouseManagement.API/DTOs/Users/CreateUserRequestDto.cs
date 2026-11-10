using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Users;

public class CreateUserRequestDto
{
    [Required(ErrorMessage = "Mã nhân viên là bắt buộc.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Mã nhân viên phải từ 3-20 ký tự.")]
    [RegularExpression(@"^[a-zA-Z0-9\-_]+$", ErrorMessage = "Mã nhân viên không được chứa khoảng trắng hoặc ký tự đặc biệt.")]
    public string EmployeeCode { get; set; } = null!;

    [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Họ và tên phải từ 2-100 ký tự.")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Username là bắt buộc.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username phải từ 3-50 ký tự.")]
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username chỉ chứa chữ cái, số và dấu gạch dưới.")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
    [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6-50 ký tự.")]
    public string Password { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Định dạng Email không hợp lệ.")]
    [StringLength(100, ErrorMessage = "Email không vượt quá 100 ký tự.")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Định dạng số điện thoại không hợp lệ.")]
    [StringLength(20, ErrorMessage = "Số điện thoại không vượt quá 20 ký tự.")]
    public string? PhoneNumber { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Avatar không hợp lệ.")]
    public int? AvatarId { get; set; }

    [Required(ErrorMessage = "Phải gán ít nhất 1 Role cho người dùng.")]
    [MinLength(1, ErrorMessage = "Phải gán ít nhất 1 Role.")]
    public List<int> RoleIds { get; set; } = new List<int>();
}
