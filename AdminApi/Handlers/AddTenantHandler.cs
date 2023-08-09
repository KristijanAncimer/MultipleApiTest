using AdminApi.Commands;
using AdminApi.Models;
using Common;
using MediatR;

namespace AdminApi.Handlers
{
	//public class AddTenantHandler : IRequestHandler<AddTenantCommand, Unit>
	//{
	//    private readonly IRepository _genericRepository;
	//    public AddTenantHandler(IRepository repository)
	//    {
	//        _genericRepository = repository;
	//    }
	//    public async Task<Unit> Handle(AddTenantCommand request, CancellationToken cancellationToken)
	//    {
	//        var tenant = new Tenant
	//        {
	//            Id = Guid.NewGuid(),
	//            Name = request.tenant.Name,
	//            MaxUsersNumber = request.tenant.maxUsersNumber
	//        };
	//        await _genericRepository.SaveOrUpdateAsync<Tenant>(tenant);
	//        return Unit.Value;
	//    }
	//}

	public class AddTenantHandler : IRequestHandler<AddTenantCommand, Tenant>
	{
		public Task<Tenant> Handle(AddTenantCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
