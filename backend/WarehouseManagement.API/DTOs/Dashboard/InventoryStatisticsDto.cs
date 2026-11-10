namespace WarehouseManagement.API.DTOs.Dashboard;

public class InventoryStatisticsDto
{
    public string WarehouseName { get; set; } = null!;
    public int TotalStockQuantity { get; set; } // Tổng số lượng sản phẩm
    public decimal TotalStockValue { get; set; } // Tổng giá trị tồn kho ước tính
}