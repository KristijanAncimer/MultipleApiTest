// <copyright file="CreateTenantCmd.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace AdminApi.Commands;
public class CreateTenantCmd
{
    public string? Name { get; set; }
    public int MaxUsersNumber { get; set; }
}