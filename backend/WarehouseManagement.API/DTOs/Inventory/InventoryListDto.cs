namespace WarehouseManagement.API.DTOs.Inventory;

public class InventoryListDto
{
    public int Id { get; set; }
    public string ProductSKU { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string WarehouseName { get; set; } = null!;
    public string LocationCode { get; set; } = null!;

    public int Quantity { get; set; }
    public int ReservedQuantity { get; set; }
    public int AvailableQuantity { get; set; }
}