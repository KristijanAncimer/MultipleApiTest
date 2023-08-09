using AdminApi.Models;
using MediatR;

namespace AdminApi.Commands
{
    public record UpdateTenantCommand : IRequest<Tenant>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public int maxUsersNumber { get; set; }
    }
}
