using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.InventoryAdjustments;

public class InventoryAdjustmentDetailDto
{
    [Required(ErrorMessage = "Sản phẩm là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Sản phẩm không hợp lệ.")]
    public int ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Vị trí không hợp lệ.")]
    public int? LocationId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Lô hàng không hợp lệ.")]
    public int? BatchId { get; set; }

    [Required(ErrorMessage = "Số lượng mới là bắt buộc.")]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng mới phải lớn hơn hoặc bằng 0.")]
    public int NewQuantity { get; set; }
}
