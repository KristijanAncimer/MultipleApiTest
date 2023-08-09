using AdminApi.Models;
using Amazon.Runtime.Internal;
using MediatR;

namespace AdminApi.Queries
{
    public record GetTenantsQuery(int page, int pageSize):IRequest<IEnumerable<Tenant>>;
}
