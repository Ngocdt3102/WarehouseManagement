using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class UnitRepository : Repository<Unit>, IUnitRepository
{
    public UnitRepository(AppDbContext context) : base(context) { }
}