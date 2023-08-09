using AdminApi.Models;
using AdminApi.Queries;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminApi.Handlers
{
    public class GetTenantsHandler : IRequestHandler<GetTenantsQuery, IEnumerable<Tenant>>
    {
        private readonly IRepository _genericRepository;
        public GetTenantsHandler(IRepository genericRespository)
        {
            _genericRepository = genericRespository;
        }
        public Task<IEnumerable<Tenant>> Handle(GetTenantsQuery request, CancellationToken cancellationToken)
        {
            
            if (request.page <= 0 || request.pageSize <= 0)
            {
                throw new NotImplementedException();
            }
            else
            {
                return Task.FromResult<IEnumerable<Tenant>>(_genericRepository.GetAll<Tenant>()
                .OrderBy(x => x.Id)
                    .Skip((request.page - 1) * request.pageSize)
                    .Take(request.pageSize)
                    .ToList());
            }
            //return Task.FromResult<IEnumerable<Tenant>>(_genericRepository.GetAll<Tenant>());
            
        }
    }
}
