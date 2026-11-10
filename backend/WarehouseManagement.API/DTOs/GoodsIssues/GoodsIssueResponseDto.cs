namespace WarehouseManagement.API.DTOs.GoodsIssues;

public class GoodsIssueResponseDto
{
    public int Id { get; set; }
    public string IssueCode { get; set; } = null!;

    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;

    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = null!;

    public int EmployeeId { get; set; }
    public string EmployeeFullName { get; set; } = null!;

    public DateTime Date { get; set; }
    public string Status { get; set; } = null!; // PENDING, APPROVED, COMPLETED, CANCELLED

    public string? Remarks { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Danh sách chi tiết phiếu xuất trả về
    public List<GoodsIssueDetailItemDto> Details { get; set; } = new List<GoodsIssueDetailItemDto>();
}

// Class phụ trợ chứa thông tin chi tiết từng dòng xuất kho
public class GoodsIssueDetailItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductSKU { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string UnitName { get; set; } = null!;

    public int Quantity { get; set; }

    public int? LocationId { get; set; }
    public string? LocationCode { get; set; }

    public int? BatchId { get; set; }
    public string? BatchCode { get; set; }
}