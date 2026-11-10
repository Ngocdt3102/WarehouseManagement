using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context) { }
}