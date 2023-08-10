// <copyright file="UpdateTenantCommand.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace AdminApi.Commands;
using AdminApi.Models;
using MediatR;

public record UpdateTenantCommand : IRequest<Tenant>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MaxUsersNumber { get; set; }
}