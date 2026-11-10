using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.GoodsIssues;

public class GoodsIssueDetailDto
{
    [Required(ErrorMessage = "Sản phẩm là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Sản phẩm không hợp lệ.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Số lượng xuất là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "Số lượng xuất phải lớn hơn 0.")]
    public int Quantity { get; set; }

    // Vị trí lấy hàng cụ thể (nếu áp dụng chiến lược Picking chặt chẽ)
    [Range(1, int.MaxValue, ErrorMessage = "ID Vị trí không hợp lệ.")]
    public int? LocationId { get; set; }

    // Thông tin ID lô hàng cần xuất (nếu xuất theo lô/FIFO/FEFO)
    [Range(1, int.MaxValue, ErrorMessage = "ID Lô hàng không hợp lệ.")]
    public int? BatchId { get; set; }
}
