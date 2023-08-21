// <copyright file="UserCommandHandler.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace TenantApi.Handlers;

using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AdminApi.Commands;
using Common;
using MediatR;
using TenantApi.HttpClients;
using TenantApi.Models;

public class UserCommandHandler : IRequestHandler<AddUserCommand, User>
{
    private readonly IRepository _genericRepository;
    private readonly ITenantService _tenantService;
    public UserCommandHandler(IRepository genericRepository, ITenantService tenantService)
    {
        _genericRepository = genericRepository;
        _tenantService = tenantService;
    }

    public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        int tenantMaxUsers = 0;

        var listOfTenants = await _tenantService.GetTenantsAsync();

        if (listOfTenants == null)
        {
            throw new InvalidDataException();
        }

        if (!listOfTenants.Any(x => x.Id == request.TenantId))
        {
            throw new InvalidDataException();
        }

        var response = await _tenantService.GetTenantById(request.TenantId);

        if (response == null)
        {
            throw new InvalidOperationException();
        }

        tenantMaxUsers = response.MaxUsersNumber;

        var actualUsersForTenant = _genericRepository.GetAll<User>().Where(x => x.TenantId == request.TenantId).Count();

        if (actualUsersForTenant < tenantMaxUsers)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                TenantId = request.TenantId
            };

            var saved = await _genericRepository.SaveOrUpdateAsync(user);
            if (!saved)
            {
                throw new InvalidDataException();
            }

            return user;
        }

        return new User { Name = "Too many users for Tenant already" };
    }
}