// <copyright file="TenantCommandHandler.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace AdminApi.Handlers;
using AdminApi.Commands;
using AdminApi.Models;
using Common;
using MediatR;
public class TenantCommandHandler : IRequestHandler<AddTenantCommand, Tenant>,
    IRequestHandler<UpdateTenantCommand, Tenant>,
    IRequestHandler<DeleteTenantCommand, bool>
{
    private readonly IRepository _genericRepository;
    public TenantCommandHandler(IRepository genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<Tenant> Handle(AddTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = new Tenant
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            MaxUsersNumber = request.MaxUsersNumber
        };
        var saved = await _genericRepository.SaveOrUpdateAsync(tenant);
        if (!saved) { throw new InvalidOperationException(); }
        return tenant;
    }

    public async Task<Tenant> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
    {
        var foundTenant = _genericRepository.GetAll<Tenant>().Single(x => x.Id == request.Id);
        foundTenant.Name = request.Name;
        foundTenant.MaxUsersNumber = request.MaxUsersNumber;

        var saved = await _genericRepository.SaveOrUpdateAsync(foundTenant);

        if (!saved)
        {
            throw new InvalidOperationException();
        }

        return foundTenant;
    }

    public async Task<bool> Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _genericRepository.DeleteAsync<Tenant>(request.Id);
        return deleted;
    }
}