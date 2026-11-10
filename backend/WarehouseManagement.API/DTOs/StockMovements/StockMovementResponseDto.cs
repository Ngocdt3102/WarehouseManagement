namespace WarehouseManagement.API.DTOs.StockMovements;

public class StockMovementResponseDto
{
    public int Id { get; set; }

    // Thông tin Sản phẩm
    public int ProductId { get; set; }
    public string ProductSKU { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string UnitName { get; set; } = null!;

    // Thông tin Kho & Vị trí
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = null!;
    public int? LocationId { get; set; }
    public string? LocationCode { get; set; }

    // Thông tin Biến động
    // Trả về dạng string (VD: "IMPORT", "EXPORT") thay vì số nguyên của Enum
    public string MovementType { get; set; } = null!;

    public int Quantity { get; set; } // Số lượng thay đổi (+ hoặc -)
    public int BeforeQuantity { get; set; }
    public int AfterQuantity { get; set; }

    // Thông tin Tham chiếu đến chứng từ gốc
    public int? ReferenceId { get; set; }
    public string? ReferenceType { get; set; } // Ví dụ: "GOODS_RECEIPT"

    // Thông tin người thực hiện
    public int UserId { get; set; }
    public string UserFullName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}