// <copyright file="DeleteTenantCommand.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace AdminApi.Commands;
using MediatR;
public record DeleteTenantCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}