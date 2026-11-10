using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Repositories.Interfaces;

public interface IGoodsIssueRepository : IRepository<GoodsIssue>
{
    Task<GoodsIssue?> GetIssueWithDetailsAsync(int id);
}