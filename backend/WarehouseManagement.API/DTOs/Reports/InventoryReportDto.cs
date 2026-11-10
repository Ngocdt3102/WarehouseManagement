namespace WarehouseManagement.API.DTOs.Reports;

public class InventoryReportDto
{
    public string ProductSKU { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public string WarehouseName { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal EstimatedValue { get; set; }
}