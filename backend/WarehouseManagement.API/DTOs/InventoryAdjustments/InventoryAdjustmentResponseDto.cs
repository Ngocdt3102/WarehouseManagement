namespace WarehouseManagement.API.DTOs.InventoryAdjustments;

public class InventoryAdjustmentResponseDto
{
    public int Id { get; set; }
    public string AdjustmentCode { get; set; } = null!;

    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string ProductSKU { get; set; } = null!;

    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = null!;

    public int? LocationId { get; set; }
    public string? LocationCode { get; set; }

    public int OldQuantity { get; set; }
    public int NewQuantity { get; set; }
    public int AdjustedQuantity { get; set; } // New - Old

    public string Reason { get; set; } = null!;

    public string Status { get; set; } = null!; // PENDING, APPROVED, REJECTED

    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}