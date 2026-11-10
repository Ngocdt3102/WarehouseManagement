namespace WarehouseManagement.API.DTOs.SerialNumbers;

public class SerialNumberResponseDto
{
    public int Id { get; set; }
    public string SerialCode { get; set; } = null!;
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public int? BatchId { get; set; }
    public string? BatchCode { get; set; }
    public string Status { get; set; } = null!; // AVAILABLE, ISSUED, DEFECTIVE
}