using WarehouseManagement.API.DTOs.Products;

namespace WarehouseManagement.API.Services.Interfaces;

public interface IProductService
{
    // Dùng ProductListDto cho hàm lấy danh sách (tối ưu data trả về)
    Task<IEnumerable<ProductListDto>> GetAllProductsAsync();

    // Dùng ProductResponseDto cho hàm lấy chi tiết
    Task<ProductResponseDto?> GetProductByIdAsync(int id);

    // Các hàm thao tác
    Task<ProductResponseDto> CreateProductAsync(CreateProductRequestDto request);
    Task<ProductResponseDto> UpdateProductAsync(int id, UpdateProductRequestDto request);
    Task<bool> DeleteProductAsync(int id);
}