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
using AdminApi.Validators;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class TenantController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRepository _repository;
    public TenantController(IMediator mediator, IRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult<Tenant>> CreateTenant(AddTenantCommand cmd)
    {
        var tenantValidator = new TenantValidator(_repository);
        var tenant = new Tenant()
        {
            Name = cmd.Name,
            MaxUsersNumber = cmd.MaxUsersNumber
        };
        var result = tenantValidator.Validate(tenant);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToList());
        }

        return await _mediator.Send(cmd);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<ActionResult<Tenant>> UpdateTenant(UpdateTenantCommand cmd)
    {
        var tenantValidator = new TenantValidator(_repository);
        var tenant = new Tenant()
        {
            Name = cmd.Name,
            MaxUsersNumber = cmd.MaxUsersNumber
        };
        var result = tenantValidator.Validate(tenant);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToList());
        }

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