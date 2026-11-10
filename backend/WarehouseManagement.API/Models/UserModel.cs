using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.Models;

public class UserModel
{
    public int Id { get; set; }

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

    [Required(ErrorMessage = "Mật khẩu mã hóa là bắt buộc.")]
    public string PasswordHash { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Định dạng Email không hợp lệ.")]
    [StringLength(100, ErrorMessage = "Email không vượt quá 100 ký tự.")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Định dạng số điện thoại không hợp lệ.")]
    [StringLength(20, ErrorMessage = "Số điện thoại không vượt quá 20 ký tự.")]
    public string? PhoneNumber { get; set; }

    public int? AvatarId { get; set; }
    public virtual File? Avatar { get; set; }

    [StringLength(500)]
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime? LastLoginAt { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } // Hỗ trợ Soft Delete[cite: 1]

    // Navigation Properties
    public ICollection<UserRoleModel> UserRoles { get; set; } = new List<UserRoleModel>();
}