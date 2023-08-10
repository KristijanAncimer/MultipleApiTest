// <copyright file="Tenant.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace AdminApi.Models;
using Common.Models;
public class Tenant : AbstractEntity
{
   public int MaxUsersNumber { get; set; }
}