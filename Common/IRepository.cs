// <copyright file="IRepository.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace Common;
using Common.Models;
public interface IRepository
{
    IQueryable<T> GetAll<T>()
        where T : AbstractEntity;
    Task<bool> SaveOrUpdateAsync<T>(T entity)
        where T : AbstractEntity;
    Task<bool> DeleteAsync<T>(T entity)
        where T : AbstractEntity;
    Task<bool> DeleteAsync<T>(Guid entityId)
        where T : AbstractEntity;
}