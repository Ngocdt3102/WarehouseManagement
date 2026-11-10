namespace WarehouseManagement.API.DTOs.Inventory;

public class InventoryResponseDto
{
    public int Id { get; set; }

    // Thông tin Sản phẩm
    public int ProductId { get; set; }
    public string ProductSKU { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string UnitName { get; set; } = null!;

    // Thông tin Kho
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = null!;

    // Thông tin Vị trí
    public int LocationId { get; set; }
    public string LocationCode { get; set; } = null!;

    // Thông tin Tồn kho
    public int Quantity { get; set; }
    public int ReservedQuantity { get; set; }
    public int AvailableQuantity { get; set; }

    public DateTime LastUpdatedAt { get; set; }
}