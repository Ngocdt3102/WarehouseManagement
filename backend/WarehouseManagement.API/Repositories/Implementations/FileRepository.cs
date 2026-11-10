using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class FileRepository : Repository<File>, IFileRepository
{
    public FileRepository(AppDbContext context) : base(context) { }
}