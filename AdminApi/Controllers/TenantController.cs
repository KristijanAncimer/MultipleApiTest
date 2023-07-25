using AdminApi.Commands;
using AdminApi.DataAccess;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly IRepository _repository;
        public TenantController()
        {
            _repository = new Repository();
        }


        [HttpPut]
        [Route("[controller]")]
        public Task<Tenant> CreateTenant(CreateTenantCmd cmd)
        {
            return _repository.CreateTenantAsync(cmd);
        }

        [HttpGet]
        [Route("[controller]/all")]
        public Task<List<Tenant>> GetAll()
        {
            return _repository.GetAllAsync();
        }
    }
}
