using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Common;

public class FilterDto : PaginationDto
{
    [StringLength(100, ErrorMessage = "Từ khóa tìm kiếm không vượt quá 100 ký tự.")]
    public string? Keyword { get; set; }

    // Tích hợp sẵn Sort vào Filter để truyền 1 object duy nhất lên Controller
    [StringLength(50, ErrorMessage = "Tên trường sắp xếp không vượt quá 50 ký tự.")]
    public string? SortBy { get; set; }

    public bool IsDescending { get; set; } = false;
}
