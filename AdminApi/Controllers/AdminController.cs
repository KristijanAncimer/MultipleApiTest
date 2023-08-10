// <copyright file="AdminController.cs" company="ROKO Labs, LLC">
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

// Ignore Spelling: Admin
namespace AdminApi.Controllers;

using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "I am Admin Api";
    }
}