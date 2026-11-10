namespace WarehouseManagement.API.DTOs.Dashboard;

public class RecentActivityDto
{
    public int Id { get; set; }
    public string ActivityType { get; set; } = null!; // "RECEIPT", "ISSUE", "TRANSFER", "ADJUSTMENT"
    public string Code { get; set; } = null!; // Mã phiếu
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
}