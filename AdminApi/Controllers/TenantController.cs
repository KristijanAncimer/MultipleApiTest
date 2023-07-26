using AdminApi.Commands;
using AdminApi.DataAccess;
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
        private readonly IConfiguration _configuration;
        private readonly IRepository _repository;
        private readonly IGenericRepository _genericRepository;
        public TenantController(IConfiguration configuration, IGenericRepository genericRepository)
        {
            //_repository = new Repository();
            _genericRepository = genericRepository;
            _configuration= configuration;
        }


        [HttpPut]
        [Route("[controller]")]
        public async Task<bool> CreateTenant(Tenant tenant)
        {
            //return _repository.CreateTenantAsync(cmd);
            return await _genericRepository.SaveOrUpdateAsync(tenant);
        }

        [HttpGet]
        [Route("[controller]/all")]
        public void GetAll()
        {
            //return _repository.GetAllAsync();
            //return _genericRepository.GetAll();
        }
    }
}
