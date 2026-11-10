using Microsoft.EntityFrameworkCore;
using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class GoodsIssueRepository : Repository<GoodsIssue>, IGoodsIssueRepository
{
    public GoodsIssueRepository(AppDbContext context) : base(context) { }

    public async Task<GoodsIssue?> GetIssueWithDetailsAsync(int id) =>
        await _dbSet.Include(gi => gi.Customer).Include(gi => gi.Warehouse).Include(gi => gi.Details).ThenInclude(d => d.Product)
        .FirstOrDefaultAsync(gi => gi.Id == id);
}