// <copyright file="GetTenantsQuery.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace AdminApi.Queries;
using AdminApi.Models;
using MediatR;

public record GetTenantsQuery(int Page, int PageSize) : IRequest<IEnumerable<Tenant>>;