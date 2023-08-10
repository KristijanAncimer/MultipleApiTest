// <copyright file="InMemoryRepository.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace Common;
using Common.Models;

public class InMemoryRepository : IRepository
{
    private Dictionary<string, Dictionary<Guid, object>> _repo = new Dictionary<string, Dictionary<Guid, object>>();
    private object _lock = new object();

    public Task<bool> DeleteAsync<T>(T entity)
        where T : AbstractEntity
    {
        if (entity == null)
        {
            return Task.FromResult(false);
        }

        string typeKey = typeof(T).FullName!;
        lock (_lock)
        {
            return Task.FromResult(_repo[typeKey].Remove(entity.Id));
        }
    }

    public Task<bool> DeleteAsync<T>(Guid entityId)
        where T : AbstractEntity
    {
        string typeKey = typeof(T).FullName!;
        lock (_lock)
        {
            return Task.FromResult(_repo[typeKey].Remove(entityId));
        }
    }

    public IQueryable<T> GetAll<T>()
        where T : AbstractEntity
    {
        string typeKey = typeof(T).FullName!;
        if (!_repo.ContainsKey(typeKey))
        {
            return new List<T>().AsQueryable();
        }

        return _repo[typeKey].Select(x => (T)x.Value).AsQueryable();
    }

    public Task<bool> SaveOrUpdateAsync<T>(T entity)
        where T : AbstractEntity
    {
        if (entity == null)
        {
            return Task.FromResult(false);
        }

        lock (_lock)
        {
            string typeKey = typeof(T).FullName!;

            if (!_repo.ContainsKey(typeKey))
            {
                _repo[typeKey] = new Dictionary<Guid, object>();
            }

            _repo[typeKey][entity.Id] = entity;
            return Task.FromResult(true);
        }
    }
}