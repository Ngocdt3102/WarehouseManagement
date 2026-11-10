namespace WarehouseManagement.API.DTOs.Products;

public class ProductListDto
{
    public int Id { get; set; }
    public string SKU { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public string? Brand { get; set; }
    public string? ImageUrl { get; set; }
    public string UnitName { get; set; } = null!;
    public string? SupplierName { get; set; }
    public int MinStock { get; set; }
    public int MaxStock { get; set; }
    public bool IsActive { get; set; }
}