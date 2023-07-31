using AdminApi.Commands;
using AdminApi.Models;
using Common;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly IGenericRepository _genericRepository;
        public TenantController(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }


        [HttpPut]
        [Route("Create")]
        public async Task<bool> CreateTenant(CreateTenantCmd cmd)
        {
            var tenant = new Tenant
            {
                Id = Guid.NewGuid(),
                Name = cmd.Name,
                MaxUsersNumber = cmd.maxUsersNumber
            };
            return await _genericRepository.SaveOrUpdateAsync(tenant);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<bool> UpdateTenant(Tenant tenant)
        {
            if (GetTenantById(tenant.Id).Name== "not found")
            {
                return false;
            }
            else
            {
                return await _genericRepository.SaveOrUpdateAsync(tenant);
            }
            
        }
        [HttpGet]
        [Route("GetById")]
        public Tenant GetTenantById(Guid id)
        {
            var tenant =GetAllTenants().AsQueryable().Where(x => x.Id == id).FirstOrDefault();
            if ( tenant==null)
            {
                return new Tenant { Name = "not found" };
            }
            return tenant;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Tenant> GetAllTenants()
        {
            return _genericRepository.GetAll<Tenant>();
        }
        [HttpDelete]
        [Route("DeleteByObject")]
        public async Task<bool> DeleteTenantByObjectAsync(Tenant tenant)
        {
            return await _genericRepository.DeleteAsync(tenant);
        }
        [HttpDelete]
        [Route("DeleteById")]
        public async Task<bool> DeleteTenantByIdAsync(Guid entityId)
        {
            return await _genericRepository.DeleteAsync<Tenant>(entityId);
        }
    }
}
