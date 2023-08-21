// <copyright file="UsersController.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace TenantApi.Controllers;

using AdminApi.Commands;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TenantApi.Models;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IRepository _genericRepository;
    private readonly IMediator _mediator;

    public UsersController(IRepository genericRepository, IMediator mediator)
    {
        _genericRepository = genericRepository;
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult<User>> CreateTenant(AddUserCommand cmd)
    {
        var user = new User()
        {
            Name = cmd.Name,
            TenantId = cmd.TenantId
        };

        return await _mediator.Send(cmd);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<bool> UpdateTenant(User user)
    {
        if (GetUserById(user.Id).Name == "not found")
        {
            return false;
        }
        else
        {
            return await _genericRepository.SaveOrUpdateAsync(user);
        }
    }

    [HttpGet]
    [Route("GetById")]
    public User GetUserById(Guid id)
    {
        var tenant = GetAllUsers().Where(x => x.Id == id).FirstOrDefault();
        if (tenant == null)
        {
            return new User { Id = Guid.Empty, Name = "not found" };
        }

        return tenant;
    }

    [HttpGet]
    [Route("GetAll")]
    public IEnumerable<User> GetAllUsers()
    {
        return _genericRepository.GetAll<User>();
    }

    [HttpDelete]
    [Route("DeleteByObject")]
    public async Task<bool> DeleteUserByObjectAsync(User user)
    {
        return await _genericRepository.DeleteAsync(user);
    }

    [HttpDelete]
    [Route("DeleteById")]
    public async Task<bool> DeleteUserByIdAsync(Guid entityId)
    {
        return await _genericRepository.DeleteAsync<User>(entityId);
    }
}