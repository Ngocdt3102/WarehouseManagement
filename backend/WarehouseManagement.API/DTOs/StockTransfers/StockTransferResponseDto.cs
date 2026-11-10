namespace WarehouseManagement.API.DTOs.StockTransfers;

public class StockTransferResponseDto
{
    public int Id { get; set; }
    public string TransferCode { get; set; } = null!;

    public int SourceWarehouseId { get; set; }
    public string SourceWarehouseName { get; set; } = null!;

    public int DestinationWarehouseId { get; set; }
    public string DestinationWarehouseName { get; set; } = null!;

    public int EmployeeId { get; set; }
    public string EmployeeFullName { get; set; } = null!;

    public DateTime Date { get; set; }
    public string Status { get; set; } = null!; // PENDING, IN_TRANSIT, COMPLETED, CANCELLED

    public string? Remarks { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public List<StockTransferDetailItemDto> Details { get; set; } = new List<StockTransferDetailItemDto>();
}

// Class phụ trợ chứa thông tin chi tiết từng dòng chuyển kho
public class StockTransferDetailItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductSKU { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string UnitName { get; set; } = null!;

    public int Quantity { get; set; }

    public int? SourceLocationId { get; set; }
    public string? SourceLocationCode { get; set; }

    public int? DestinationLocationId { get; set; }
    public string? DestinationLocationCode { get; set; }

    public int? BatchId { get; set; }
    public string? BatchCode { get; set; }
}