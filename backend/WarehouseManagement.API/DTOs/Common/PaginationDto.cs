using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Common;

public class PaginationDto
{
    [Range(1, int.MaxValue, ErrorMessage = "PageNumber phải lớn hơn 0.")]
    public int PageNumber { get; set; } = 1;

    [Range(1, 100, ErrorMessage = "PageSize phải từ 1 đến 100.")]
    public int PageSize { get; set; } = 20;
}