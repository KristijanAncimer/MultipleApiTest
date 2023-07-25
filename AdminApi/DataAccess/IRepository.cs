using AdminApi.Commands;
using AdminApi.Models;

namespace AdminApi.DataAccess
{
    public interface IRepository
    {
        Task<Tenant> CreateTenantAsync(CreateTenantCmd cmd);

        Task<List<Tenant>> GetAllAsync();
    }
}