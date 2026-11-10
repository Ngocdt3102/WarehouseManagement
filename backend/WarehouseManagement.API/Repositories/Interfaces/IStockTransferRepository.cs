using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Repositories.Interfaces;

public interface IStockTransferRepository : IRepository<StockTransfer>
{
    Task<StockTransfer?> GetTransferWithDetailsAsync(int id);
}