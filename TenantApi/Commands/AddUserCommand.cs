// <copyright file="AddUserCommand.cs" company="ROKO Labs, LLC">
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

namespace AdminApi.Commands;

using MediatR;
using TenantApi.Models;

public record AddUserCommand : IRequest<User>
{
    public string Name { get; set; } = string.Empty;
    public Guid TenantId { get; set; }
}