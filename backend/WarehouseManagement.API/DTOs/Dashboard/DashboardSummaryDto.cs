namespace WarehouseManagement.API.DTOs.Dashboard;

public class DashboardSummaryDto
{
    public int TotalProducts { get; set; }
    public int TotalWarehouses { get; set; }
    public int LowStockItems { get; set; } // Số mặt hàng dưới MinStock
    public int PendingReceipts { get; set; }
    public int PendingIssues { get; set; }
}