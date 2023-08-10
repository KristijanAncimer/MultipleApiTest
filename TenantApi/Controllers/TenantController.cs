// <copyright file="TenantController.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

// Ignore Spelling: Api
namespace TenantApi.Controllers;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TenantController : ControllerBase
{
    [HttpGet]
    [Route("[controller]/Index")]
    public async Task<TenantTestResponse> Get()
    {
        var result = new TenantTestResponse
        {
            ApiName = "Tenant Api",
        };

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://adminapi");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("Admin");

            response.EnsureSuccessStatusCode();

            var responseText = await response.Content.ReadAsStringAsync();

            result.OtherApiResponse = responseText;
        }

        return result;
    }

    public class TenantTestResponse
    {
        public string ApiName { get; set; } = null!;
        public string? OtherApiResponse { get; set; }
    }
}