namespace WarehouseManagement.API.DTOs.Stocktakes;

public class StocktakeResponseDto
{
    public int Id { get; set; }
    public string StocktakeCode { get; set; } = null!;

    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = null!;

    public string Status { get; set; } = null!; // PLANNED, IN_PROGRESS, COMPLETED

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public string? Remarks { get; set; }

    public string CreatedByName { get; set; } = null!;

    public List<StocktakeDetailDto> Details { get; set; } = new();
}