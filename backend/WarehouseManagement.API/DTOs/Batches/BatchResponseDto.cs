namespace WarehouseManagement.API.DTOs.Batches;

public class BatchResponseDto
{
    public int Id { get; set; }
    public string BatchCode { get; set; } = null!;
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public DateTime? ManufactureDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive { get; set; }
}