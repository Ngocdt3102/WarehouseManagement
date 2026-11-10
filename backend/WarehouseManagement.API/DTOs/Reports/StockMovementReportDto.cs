namespace WarehouseManagement.API.DTOs.Reports;

public class StockMovementReportDto
{
    public DateTime Date { get; set; }
    public string MovementType { get; set; } = null!; // IN, OUT
    public string ReferenceCode { get; set; } = null!; // Mã phiếu nhập/xuất
    public string ProductSKU { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
    public string WarehouseName { get; set; } = null!;
}