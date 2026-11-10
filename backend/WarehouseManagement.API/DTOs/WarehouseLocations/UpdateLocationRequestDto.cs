using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.WarehouseLocations;

public class UpdateLocationRequestDto
{
    // Thông thường Mã vị trí (Code) và Kho (WarehouseId) không được sửa sau khi tạo 
    // vì chúng liên kết vật lý với thực tế, do đó DTO này chỉ cho phép sửa mô tả và trạng thái.

    [StringLength(50, ErrorMessage = "Zone không vượt quá 50 ký tự.")]
    public string? Zone { get; set; }

    [StringLength(50, ErrorMessage = "Rack không vượt quá 50 ký tự.")]
    public string? Rack { get; set; }

    [StringLength(50, ErrorMessage = "Shelf không vượt quá 50 ký tự.")]
    public string? Shelf { get; set; }

    [StringLength(50, ErrorMessage = "Bin không vượt quá 50 ký tự.")]
    public string? Bin { get; set; }

    public bool IsActive { get; set; }
}