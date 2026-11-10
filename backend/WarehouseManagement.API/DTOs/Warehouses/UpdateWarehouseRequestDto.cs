using System.ComponentModel.DataAnnotations;
using WarehouseManagement.API.Enums;

namespace WarehouseManagement.API.DTOs.Warehouses;

public class UpdateWarehouseRequestDto
{
    // Giữ nguyên logic không cho phép sửa Mã kho (Code) để bảo toàn dữ liệu liên kết

    [Required(ErrorMessage = "Tên kho là bắt buộc.")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Tên kho phải từ 2-150 ký tự.")]
    public string Name { get; set; } = null!;

    [StringLength(250, ErrorMessage = "Địa chỉ không vượt quá 250 ký tự.")]
    public string? Address { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Thủ kho không hợp lệ.")]
    public int? ManagerId { get; set; }

    [Required(ErrorMessage = "Trạng thái là bắt buộc.")]
    public WarehouseStatus Status { get; set; }
}
