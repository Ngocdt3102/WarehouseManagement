using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Stocktakes;

public class StocktakeDetailDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductSKU { get; set; } = null!;
    public string ProductName { get; set; } = null!;

    public int? LocationId { get; set; }

    public int ExpectedQuantity { get; set; } // Tồn kho lý thuyết trên hệ thống
    public int? CountedQuantity { get; set; } // Số lượng đếm thực tế
    public int? Variance => CountedQuantity.HasValue ? CountedQuantity.Value - ExpectedQuantity : null; // Chênh lệch

    [StringLength(250)]
    public string? Reason { get; set; } // Giải trình chênh lệch
}
