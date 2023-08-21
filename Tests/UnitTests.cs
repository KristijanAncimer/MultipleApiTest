// <copyright file="UnitTests.cs" company="ROKO Labs, LLC">
//
// Copyright (C) ROKO Labs, LLC - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
//
// </copyright>

namespace Tests;

using AdminApi.Models;
using AdminApi.Queries;
using Common;
using Common.Models;
using TenantApi.Models;
using Tenant = AdminApi.Models.Tenant;

public class UnitTests
{
    private readonly InMemoryRepository _repository;
    public UnitTests()
    {
        _repository = new InMemoryRepository();
    }

    [Fact]
    public void SaveOrUpdates_Succeeds()
    {
        var tenant = new Tenant() { Id = Guid.NewGuid(), Name = "Batman", MaxUsersNumber = 3 };
        var user = new User() { Id = Guid.NewGuid(), Name = "Alfred", TenantId = tenant.Id };

        _repository.SaveOrUpdateAsync(user);
        _repository.SaveOrUpdateAsync(tenant);

        var tenants = _repository.GetAll<Tenant>();
        var users = _repository.GetAll<User>();

        Assert.Contains(tenant, tenants);
        Assert.Contains(user, users);
    }

    [Fact]
    public async void GetAllSucceeds()
    {
        var entities1 = new List<EntityTest1>
        {
            new EntityTest1 { Id = Guid.NewGuid(), Name = "name1", TestString = "testblablabla1" },
            new EntityTest1 { Id = Guid.NewGuid(), Name = "name2", TestString = "testblablabla2" },
            new EntityTest1 { Id = Guid.NewGuid(), Name = "name3", TestString = "testblablabla3" },
            new EntityTest1 { Id = Guid.NewGuid(), Name = "name4", TestString = "testblablabla4" },
            new EntityTest1 { Id = Guid.NewGuid(), Name = "name5", TestString = "testblablabla5" }
        };
        var entities2 = new List<EntityTest2>
        {
            new EntityTest2 { Id = Guid.NewGuid(), Name = "name1", TestInteger = 1 },
            new EntityTest2 { Id = Guid.NewGuid(), Name = "name2", TestInteger = 2 },
            new EntityTest2 { Id = Guid.NewGuid(), Name = "name3", TestInteger = 3 },
            new EntityTest2 { Id = Guid.NewGuid(), Name = "name4", TestInteger = 4 },
            new EntityTest2 { Id = Guid.NewGuid(), Name = "name5", TestInteger = 5 }
        };
        foreach (var entity in entities1)
        {
            await _repository.SaveOrUpdateAsync(entity);
        }

        foreach (var entity in entities2)
        {
            await _repository.SaveOrUpdateAsync(entity);
        }

        var entity1 = _repository.GetAll<EntityTest1>();
        var entity2 = _repository.GetAll<EntityTest2>();

        Assert.Equal(entities1.Count(), entity1.Count());
        Assert.Equal(entities2.Count(), entity2.Count());

        foreach (var entity in entities1)
        {
            Assert.Contains(entity, entities1);
        }

        foreach (var entity in entities2)
        {
            Assert.Contains(entity, entities2);
        }
    }

    public class EntityTest1 : AbstractEntity
    {
        public string? Name { get; set; }
        public string? TestString { get; set; }
    }

    public class EntityTest2 : AbstractEntity
    {
        public string? Name { get; set; }
        public int TestInteger { get; set; }
    }
}