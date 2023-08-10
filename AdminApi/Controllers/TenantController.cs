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
        private readonly IMediator _mediator;
        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("Create")]
        public async Task<Tenant> CreateTenant(AddTenantCommand cmd)
        {
            return await _mediator.Send(cmd);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<Tenant> UpdateTenant(UpdateTenantCommand cmd)
        {
            return await _mediator.Send(cmd);
        }

        [HttpGet]
        [Route("GetAll")]
        public  async Task<IEnumerable<Tenant>> GetAllTenants(int page, int pageSize)
        {

            return await _mediator.Send(new GetTenantsQuery(page, pageSize));
        }
        [HttpDelete]
        [Route("DeleteById")]
        public async Task<bool> DeleteTenantByIdAsync(DeleteTenantCommand cmd)
        {
            return await _mediator.Send(cmd);
        }
    }
}
