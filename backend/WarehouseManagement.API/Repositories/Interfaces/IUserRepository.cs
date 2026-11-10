using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetUserWithRolesAsync(int userId);
}