namespace WarehouseManagement.API.DTOs.Warehouses;

public class WarehouseResponseDto
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Address { get; set; }

    public int? ManagerId { get; set; }
    // Bổ sung ManagerName để UI hiển thị trực tiếp tên Thủ kho
    public string? ManagerName { get; set; }

    // Trả về string (vd: "ACTIVE", "INACTIVE") thay vì số nguyên của Enum để Frontend dễ đọc
    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}