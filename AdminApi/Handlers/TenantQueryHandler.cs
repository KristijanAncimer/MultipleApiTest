// <copyright file="TenantQueryHandler.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace AdminApi.Handlers;

using AdminApi.Models;
using AdminApi.Queries;
using Common;
using MediatR;
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