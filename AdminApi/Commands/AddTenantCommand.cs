using AdminApi.Models;

using MediatR;

namespace AdminApi.Commands
{
    //public record AddTenantCommand(CreateTenantCmd tenant) : IRequest;

    public record AddTenantCommand : IRequest<Tenant>
    {
		public string Name { get; set; } = string.Empty;
		public int maxUsersNumber { get; set; }
	}
}
