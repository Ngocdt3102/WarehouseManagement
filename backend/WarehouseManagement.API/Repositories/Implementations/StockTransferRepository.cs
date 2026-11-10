using Microsoft.EntityFrameworkCore;
using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class StockTransferRepository : Repository<StockTransfer>, IStockTransferRepository
{
    public StockTransferRepository(AppDbContext context) : base(context) { }

    public async Task<StockTransfer?> GetTransferWithDetailsAsync(int id) =>
        await _dbSet.Include(st => st.SourceWarehouse).Include(st => st.DestinationWarehouse)
        .Include(st => st.Details).ThenInclude(d => d.Product).FirstOrDefaultAsync(st => st.Id == id);
}