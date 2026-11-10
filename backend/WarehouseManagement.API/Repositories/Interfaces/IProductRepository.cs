using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Repositories.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetProductWithDetailsAsync(int id);
    Task<bool> IsSkuExistsAsync(string sku);
}