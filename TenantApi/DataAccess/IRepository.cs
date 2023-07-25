using TenantApi.Commands;
using TenantApi.Models;

namespace TenantApi.DataAccess
{
    public interface IRepository
    {
        Task<User> CreateUserAsync(CreateUserCmd cmd);

        Task<List<User>> GetAllUsers();

        void DeleteUser(User user);

        Task<User> GetById(Guid id);
    }
}