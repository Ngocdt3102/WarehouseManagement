using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class StocktakeRepository : Repository<Stocktake>, IStocktakeRepository
{
    public StocktakeRepository(AppDbContext context) : base(context) { }
}