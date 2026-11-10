using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Repositories.Interfaces;

public interface IGoodsReceiptRepository : IRepository<GoodsReceipt>
{
    Task<GoodsReceipt?> GetReceiptWithDetailsAsync(int id);
}