using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class BatchRepository : Repository<Batch>, IBatchRepository
{
    public BatchRepository(AppDbContext context) : base(context) { }
}