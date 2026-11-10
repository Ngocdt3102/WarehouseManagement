using System.ComponentModel.DataAnnotations;
using WarehouseManagement.API.DTOs.Common;

namespace WarehouseManagement.API.DTOs.Inventory;

public class InventoryFilterDto : FilterDto
{
    [Range(1, int.MaxValue, ErrorMessage = "ID Kho không hợp lệ.")]
    public int? WarehouseId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Sản phẩm không hợp lệ.")]
    public int? ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ID Vị trí không hợp lệ.")]
    public int? LocationId { get; set; }

    // Lọc các sản phẩm còn tồn kho khả dụng (AvailableQuantity > 0)
    public bool? InStockOnly { get; set; }

    // Lọc theo danh mục sản phẩm để tiện tra cứu
    [Range(1, int.MaxValue, ErrorMessage = "ID Danh mục không hợp lệ.")]
    public int? CategoryId { get; set; }
}
