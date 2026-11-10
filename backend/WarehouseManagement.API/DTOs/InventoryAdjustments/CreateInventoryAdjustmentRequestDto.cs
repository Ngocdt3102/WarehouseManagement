using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.InventoryAdjustments;

public class CreateInventoryAdjustmentRequestDto
{
    [Required(ErrorMessage = "Kho điều chỉnh là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Kho không hợp lệ.")]
    public int WarehouseId { get; set; }

    [Required(ErrorMessage = "Lý do điều chỉnh là bắt buộc.")]
    [StringLength(500, MinimumLength = 3, ErrorMessage = "Lý do điều chỉnh phải từ 3-500 ký tự.")]
    public string Reason { get; set; } = null!;

    [Required(ErrorMessage = "Danh sách chi tiết điều chỉnh không được để trống.")]
    [MinLength(1, ErrorMessage = "Phải có ít nhất 1 sản phẩm cần điều chỉnh.")]
    public List<InventoryAdjustmentDetailDto> Details { get; set; } = new();
}
