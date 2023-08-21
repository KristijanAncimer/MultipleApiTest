// <copyright file="ITenantService.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace TenantApi.HttpClients;

using System.Net.Http;
using TenantApi.Models;

public interface ITenantService
{
    Task<Tenant?> GetTenantById(Guid tenantId);

    Task<List<Tenant>?> GetTenantsAsync();
}