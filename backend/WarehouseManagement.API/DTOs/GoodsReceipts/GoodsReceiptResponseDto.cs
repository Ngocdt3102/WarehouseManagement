namespace WarehouseManagement.API.DTOs.GoodsReceipts;

public class GoodsReceiptResponseDto
{
    public int Id { get; set; }
    public string ReceiptCode { get; set; } = null!;

    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = null!;

    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = null!;

    public int EmployeeId { get; set; }
    public string EmployeeFullName { get; set; } = null!;

    public DateTime Date { get; set; }
    public string Status { get; set; } = null!; // PENDING, APPROVED, COMPLETED, CANCELLED

    public string? Remarks { get; set; }
    public decimal TotalAmount { get; set; } // Tổng giá trị phiếu nhập (tính bằng Số lượng * Đơn giá)

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Danh sách chi tiết phiếu nhập trả về
    public List<GoodsReceiptDetailItemDto> Details { get; set; } = new List<GoodsReceiptDetailItemDto>();
}

// Class phụ trợ dùng riêng cho việc trả về danh sách chi tiết
public class GoodsReceiptDetailItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductSKU { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string UnitName { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal => Quantity * UnitPrice; // Tính tự động thành tiền

    public int? LocationId { get; set; }
    public string? LocationCode { get; set; }

    public string? BatchCode { get; set; }
    public DateTime? ExpiryDate { get; set; }
}