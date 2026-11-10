namespace WarehouseManagement.API.DTOs.Products;

public class ProductResponseDto
{
    public int Id { get; set; }
    public string SKU { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public string? Brand { get; set; }
    public int? ImageId { get; set; }
    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;

    public int UnitId { get; set; }
    public string UnitName { get; set; } = null!;

    public int? SupplierId { get; set; }
    public string? SupplierName { get; set; }

    public string? Barcode { get; set; }
    public int MinStock { get; set; }
    public int MaxStock { get; set; }
    public double Weight { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}