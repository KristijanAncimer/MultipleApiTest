using MediatR;

namespace AdminApi.Commands
{
    public record AddTenantCommand(CreateTenantCmd tenant) : IRequest;
}
