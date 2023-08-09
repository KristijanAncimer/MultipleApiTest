using AdminApi.Commands;
using AdminApi.Models;
using AdminApi.Queries;
using Common;
using Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly IRepository _genericRepository;
        private readonly IMediator _mediator;
        public TenantController(IRepository genericRepository, IMediator mediator)
        {
            _genericRepository = genericRepository;
            _mediator = mediator;
        }


        [HttpPost]
        [Route("Create")]
        public async Task<bool> CreateTenant(CreateTenantCmd cmd)
        {
            //var tenant = new Tenant
            //{
            //    Id = Guid.NewGuid(),
            //    Name = cmd.Name,
            //    MaxUsersNumber = cmd.maxUsersNumber
            //};
            //return await _genericRepository.SaveOrUpdateAsync(tenant);
            return await _mediator.Send(new AddTenantCommand(cmd));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<bool>> UpdateTenant(Tenant tenant)
        {
            var foundTenant =_genericRepository.GetAll<Tenant>().AsQueryable().Where(x=>x.Id==tenant.Id).FirstOrDefault();

            if (foundTenant == null)
            {
                return NotFound();
            }

            return await _genericRepository.SaveOrUpdateAsync(tenant);
        }

        [HttpGet]
        [Route("GetAll")]
        public  async Task<IEnumerable<Tenant>> GetAllTenants(int page, int pageNumber)
        {
            //if (page <= 0 || pageSize <= 0) 
            //{ 
            //    return BadRequest(); 
            //}
            //else
            //{
            //    return _genericRepository.GetAll<Tenant>()
            //        .OrderBy(x => x.Id)
            //        .Skip((page - 1) * pageSize)
            //        .Take(pageSize)
            //        .ToList();
            //}
            return await _mediator.Send(new GetTenantsQuery(page, pageNumber));
        }
        [HttpDelete]
        [Route("DeleteById")]
        public async Task<bool> DeleteTenantByIdAsync(Guid entityId)
        {
            return await _genericRepository.DeleteAsync<Tenant>(entityId);
        }
    }
}
