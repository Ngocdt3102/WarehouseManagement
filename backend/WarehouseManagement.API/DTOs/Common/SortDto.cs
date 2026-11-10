using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Common;


public class SortDto
{
    public string? SortBy { get; set; }
    public bool IsDescending { get; set; } = false;
}