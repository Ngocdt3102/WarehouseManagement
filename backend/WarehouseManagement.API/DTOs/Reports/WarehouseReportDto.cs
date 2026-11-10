namespace WarehouseManagement.API.DTOs.Reports;

public class WarehouseReportDto
{
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = null!;
    public int TotalUniqueProducts { get; set; }
    public int TotalQuantity { get; set; }
    public decimal CapacityUtilization { get; set; } // % sử dụng kho (nếu có cấu hình sức chứa)
}