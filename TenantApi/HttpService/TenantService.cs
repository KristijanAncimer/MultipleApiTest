// <copyright file="TenantService.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace TenantApi.HttpClients;

using System.Net.Http;
using System.Net.Http.Headers;
using TenantApi.Models;

public class TenantService : ITenantService
{
    private readonly HttpClient _httpClient;

    public TenantService(string? adminApiUrl)
    {
        if (string.IsNullOrEmpty(adminApiUrl))
        {
            throw new ArgumentException(nameof(adminApiUrl));
        }

        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(adminApiUrl);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<Tenant?> GetTenantById(Guid tenantId)
    {
        return await _httpClient.GetFromJsonAsync<Tenant>($"Tenant/GetById/{tenantId}");
    }

    public async Task<List<Tenant>?> GetTenantsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Tenant>>("Tenant/GetAllNoPagination");
    }
}