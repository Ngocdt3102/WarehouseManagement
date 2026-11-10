using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Suppliers;

public class UpdateSupplierRequestDto
{
    // Thông thường Mã nhà cung cấp (Code) không được phép sửa sau khi tạo để tránh ảnh hưởng dữ liệu, 
    // nên DTO Update sẽ chỉ cho phép cập nhật các thông tin dưới đây:

    [Required(ErrorMessage = "Tên nhà cung cấp là bắt buộc.")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Tên nhà cung cấp phải từ 2-150 ký tự.")]
    public string Name { get; set; } = null!;

    [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
    [StringLength(20, ErrorMessage = "Số điện thoại không vượt quá 20 ký tự.")]
    public string? Phone { get; set; }

    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    [StringLength(100, ErrorMessage = "Email không vượt quá 100 ký tự.")]
    public string? Email { get; set; }

    [StringLength(250, ErrorMessage = "Địa chỉ không vượt quá 250 ký tự.")]
    public string? Address { get; set; }

    public bool IsActive { get; set; }
}