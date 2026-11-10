using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class SerialNumberRepository : Repository<SerialNumber>, ISerialNumberRepository
{
    public SerialNumberRepository(AppDbContext context) : base(context) { }
}