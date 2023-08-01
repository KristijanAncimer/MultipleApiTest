using Common;
using Common.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Reflection.Emit;

namespace Tests
{

    public class UnitTests
    {
        InMemoryRepository _repository;
        public UnitTests()
        {
            _repository=new InMemoryRepository();
        }
        [Fact]
        public void SaveOrUpdates_Succedess()
        {
            // kreirati 1 tenanta i usera
        }

        [Fact]
        public async void GetAllSucceds()
        {
            var entities1 = new List<EntityTest1>
            {
                new EntityTest1{Id=Guid.NewGuid(), Name="name1", testString="testblablabla1"},
                new EntityTest1{Id=Guid.NewGuid(), Name="name2", testString="testblablabla2"},
                new EntityTest1{Id=Guid.NewGuid(), Name="name3", testString="testblablabla3"},
                new EntityTest1{Id=Guid.NewGuid(), Name="name4", testString="testblablabla4"},
                new EntityTest1{Id=Guid.NewGuid(), Name="name5", testString="testblablabla5"}
            };
            var entities2 = new List<EntityTest2>
            {
                new EntityTest2{Id=Guid.NewGuid(), Name="name1", testInteger=1},
                new EntityTest2{Id=Guid.NewGuid(), Name="name2", testInteger=2},
                new EntityTest2{Id=Guid.NewGuid(), Name="name3", testInteger=3},
                new EntityTest2{Id=Guid.NewGuid(), Name="name4", testInteger=4},
                new EntityTest2{Id=Guid.NewGuid(), Name="name5", testInteger=5}
            };
            foreach (var entity in entities1)
            {
                await _repository.SaveOrUpdateAsync(entity);
            }
            foreach (var entity in entities2)
            {
                await _repository.SaveOrUpdateAsync(entity);
            }
        }

        public class EntityTest1 : AbstractEntity
        {
            public string? testString { get; set; }
        }

        public class EntityTest2:AbstractEntity 
        {
            public int testInteger { get; set; }
        }
    }
}