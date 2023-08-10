// <copyright file="AbstractEntity.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace Common.Models;

using MongoDB.Bson.Serialization.Attributes;
public abstract class AbstractEntity
{
    [BsonId]
    public Guid Id { get; set; }
    public string? Name { get; set; }
}