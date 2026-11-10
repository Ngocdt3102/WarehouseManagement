using WarehouseManagement.API.DTOs.Products;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;
using WarehouseManagement.API.Services.Interfaces;

namespace WarehouseManagement.API.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductListDto>> GetAllProductsAsync()
    {
        // Lấy dữ liệu và Join các bảng (Category, Unit, Supplier, Image)
        var products = await _unitOfWork.Products.GetAllProductsWithDetailsAsync();

        // Map sang ProductListDto (chỉ lấy các trường cần thiết cho dạng lưới/bảng)
        return products.Select(p => new ProductListDto
        {
            Id = p.Id,
            SKU = p.SKU,
            Name = p.Name,
            CategoryName = p.Category?.Name ?? "N/A",
            Brand = p.Brand,
            ImageUrl = p.Image?.DownloadUrl,
            UnitName = p.Unit?.Name ?? "N/A",
            SupplierName = p.Supplier?.Name,
            MinStock = p.MinStock,
            MaxStock = p.MaxStock,
            IsActive = p.IsActive
        });
    }

    public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
    {
        var p = await _unitOfWork.Products.GetProductWithDetailsAsync(id);
        if (p == null) return null;

        // Map sang ProductResponseDto (Đầy đủ chi tiết)
        return new ProductResponseDto
        {
            Id = p.Id,
            SKU = p.SKU,
            Name = p.Name,
            Description = p.Description,
            Brand = p.Brand,
            ImageId = p.ImageId,
            ImageUrl = p.Image?.DownloadUrl,
            CategoryId = p.CategoryId,
            CategoryName = p.Category?.Name ?? "N/A",
            UnitId = p.UnitId,
            UnitName = p.Unit?.Name ?? "N/A",
            SupplierId = p.SupplierId,
            SupplierName = p.Supplier?.Name,
            Barcode = p.Barcode,
            MinStock = p.MinStock,
            MaxStock = p.MaxStock,
            Weight = p.Weight,
            IsActive = p.IsActive,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt
        };
    }

    public async Task<ProductResponseDto> CreateProductAsync(CreateProductRequestDto request)
    {
        // 1. Kiểm tra SKU (SKU không được trùng)
        if (await _unitOfWork.Products.IsSkuExistsAsync(request.SKU))
        {
            throw new InvalidOperationException($"Mã SKU '{request.SKU}' đã tồn tại trong hệ thống.");
        }

        // 2. Map từ DTO sang Entity
        var newProduct = new Product
        {
            SKU = request.SKU,
            Name = request.Name,
            Description = request.Description,
            Brand = request.Brand,
            ImageId = request.ImageId,
            CategoryId = request.CategoryId,
            UnitId = request.UnitId,
            SupplierId = request.SupplierId,
            Barcode = request.Barcode,
            MinStock = request.MinStock,
            MaxStock = request.MaxStock,
            Weight = request.Weight,
            IsActive = true, // Mặc định kích hoạt
            CreatedAt = DateTime.UtcNow
        };

        // 3. Thêm vào CSDL
        await _unitOfWork.Products.AddAsync(newProduct);
        await _unitOfWork.SaveChangesAsync();

        // 4. Trả về Response (Load lại bằng hàm GetProductByIdAsync để có đủ Name của Category/Unit)
        return await GetProductByIdAsync(newProduct.Id)
               ?? throw new Exception("Lỗi truy xuất dữ liệu sau khi tạo mới.");
    }

    public async Task<ProductResponseDto> UpdateProductAsync(int id, UpdateProductRequestDto request)
    {
        var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);
        if (existingProduct == null)
        {
            throw new KeyNotFoundException($"Không tìm thấy sản phẩm với ID {id}.");
        }

        // Lưu ý: Trong UpdateProductRequestDto của bạn không có trường SKU
        // Đây là thiết kế rất chuẩn (Không cho phép đổi SKU sau khi đã tạo để tránh hỏng dữ liệu liên kết)

        // Cập nhật thông tin
        existingProduct.Name = request.Name;
        existingProduct.Description = request.Description;
        existingProduct.CategoryId = request.CategoryId;
        existingProduct.UnitId = request.UnitId;
        existingProduct.SupplierId = request.SupplierId;
        existingProduct.Barcode = request.Barcode;
        existingProduct.MinStock = request.MinStock;
        existingProduct.MaxStock = request.MaxStock;
        existingProduct.Weight = request.Weight;
        existingProduct.IsActive = request.IsActive;
        existingProduct.UpdatedAt = DateTime.UtcNow;

        // Nếu DTO Update của bạn bổ sung thêm ImageId / Brand, hãy gán vào đây
        // existingProduct.ImageId = request.ImageId;
        // existingProduct.Brand = request.Brand;

        _unitOfWork.Products.Update(existingProduct);
        await _unitOfWork.SaveChangesAsync();

        return await GetProductByIdAsync(existingProduct.Id)
               ?? throw new Exception("Lỗi truy xuất dữ liệu sau khi cập nhật.");
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product == null) return false;

        // Soft Delete
        product.IsActive = false;
        product.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}