using AdminApi.Models;
using AdminApi.Queries;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Specialized;

namespace AdminApi.Handlers
{
    public class TenantQueryHandler : IRequestHandler<GetTenantsQuery, IEnumerable<Tenant>>
    {
        private readonly IRepository _genericRepository;
        public TenantQueryHandler(IRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public Task<IEnumerable<Tenant>> Handle(GetTenantsQuery request, CancellationToken cancellationToken)
        {
            if (request.page <= 0 || request.pageSize <= 0)
            {
                throw new ArgumentException();
            }
            else
            {
                return Task.FromResult<IEnumerable<Tenant>>(_genericRepository.GetAll<Tenant>()
                .OrderBy(x => x.Id)
                    .Skip((request.page - 1) * request.pageSize)
                    .Take(request.pageSize)
                    .ToList());
            }
        }
    }
}
