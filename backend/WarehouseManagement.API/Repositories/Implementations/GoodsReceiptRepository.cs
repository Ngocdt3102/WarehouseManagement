using Microsoft.EntityFrameworkCore;
using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class GoodsReceiptRepository : Repository<GoodsReceipt>, IGoodsReceiptRepository
{
    public GoodsReceiptRepository(AppDbContext context) : base(context) { }

    public async Task<GoodsReceipt?> GetReceiptWithDetailsAsync(int id) =>
        await _dbSet.Include(gr => gr.Supplier).Include(gr => gr.Warehouse).Include(gr => gr.Details).ThenInclude(d => d.Product)
        .FirstOrDefaultAsync(gr => gr.Id == id);
}