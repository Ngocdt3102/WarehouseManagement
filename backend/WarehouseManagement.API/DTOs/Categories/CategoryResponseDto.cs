namespace WarehouseManagement.API.DTOs.Categories;

public class CategoryResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public int? ImageId { get; set; }
    public string? ImageUrl { get; set; }

    public int? ParentCategoryId { get; set; }

    // Bổ sung thêm trường này để Frontend hiển thị tên danh mục cha dễ dàng hơn mà không cần gọi API phụ
    public string? ParentCategoryName { get; set; }

    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}