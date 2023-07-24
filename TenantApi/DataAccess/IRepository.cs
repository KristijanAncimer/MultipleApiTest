using TenantApi.Models;

namespace TenantApi.DataAccess
{
    public interface IRepository
    {
        Task CreateUser(User user);
        Task<List<User>> GetAllUsers();

        public void DeleteUser(User user);
    }
}