using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.StockTransfers;

public class StockTransferDetailDto
{
    [Required(ErrorMessage = "Sản phẩm là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Sản phẩm không hợp lệ.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Số lượng chuyển là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "Số lượng chuyển phải lớn hơn 0.")]
    public int Quantity { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Vị trí nguồn không hợp lệ.")]
    public int? SourceLocationId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Vị trí đích không hợp lệ.")]
    public int? DestinationLocationId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Lô hàng không hợp lệ.")]
    public int? BatchId { get; set; }
}
