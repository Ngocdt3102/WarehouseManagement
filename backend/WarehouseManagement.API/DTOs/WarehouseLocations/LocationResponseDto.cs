namespace WarehouseManagement.API.DTOs.WarehouseLocations;

public class LocationResponseDto
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;

    public int WarehouseId { get; set; }
    // Bổ sung WarehouseName để UI dễ dàng hiển thị danh sách
    public string WarehouseName { get; set; } = null!;

    public string? Zone { get; set; }
    public string? Rack { get; set; }
    public string? Shelf { get; set; }
    public string? Bin { get; set; }

    public bool IsActive { get; set; }
}