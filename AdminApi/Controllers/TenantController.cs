// <copyright file="TenantController.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace AdminApi.Controllers;

using AdminApi.Commands;
using AdminApi.Models;
using AdminApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class TenantController : ControllerBase
{
    private readonly IMediator _mediator;
    public TenantController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<Tenant> CreateTenant(AddTenantCommand cmd)
    {
        return await _mediator.Send(cmd);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<Tenant> UpdateTenant(UpdateTenantCommand cmd)
    {
        return await _mediator.Send(cmd);
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IEnumerable<Tenant>> GetAllTenants(int page, int pageSize)
    {
        return await _mediator.Send(new GetTenantsQuery(page, pageSize));
    }

    [HttpDelete]
    [Route("DeleteById")]
    public async Task<bool> DeleteTenantByIdAsync(DeleteTenantCommand cmd)
    {
        return await _mediator.Send(cmd);
    }
}