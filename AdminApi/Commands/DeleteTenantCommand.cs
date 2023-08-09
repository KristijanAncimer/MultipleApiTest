using AdminApi.Models;
using MediatR;

namespace AdminApi.Commands
{
    public record DeleteTenantCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

