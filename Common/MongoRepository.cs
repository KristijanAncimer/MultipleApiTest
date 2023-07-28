using Common.Models;

using MongoDB.Driver;

namespace Common
{
	public class MongoRepository : IGenericRepository
	{
		private readonly MongoClient _client;
		private readonly IMongoDatabase _database;


		public MongoRepository(string connectionString, string databaseName)
		{
			_client = new MongoClient(connectionString);
			_database = _client.GetDatabase(databaseName);
		}

		public async Task<bool> DeleteAsync<T>(Guid entityId) where T : AbstractEntity
		{
			var bulkOps = new List<DeleteOneModel<T>>
			{
				new DeleteOneModel<T>(Builders<T>.Filter.Eq("_id", entityId))
			};

			var collection = GetCollection<T>();
			await collection.BulkWriteAsync(bulkOps);

			return true;
		}

		public Task<bool> DeleteAsync<T>(T entity) where T : AbstractEntity
		{
			if (entity == null)
			{
				return Task.FromResult(false);
			}

			return DeleteAsync<T>(entity.Id);
		}

		public List<T> GetAll<T>() where T : AbstractEntity
		{
			return GetCollection<T>().AsQueryable().ToList();
		}

		public async Task<bool> SaveOrUpdateAsync<T>(T entity) where T : AbstractEntity
		{
			if (entity == null)
			{
				return false;
			}

			var bulkOps = new List<ReplaceOneModel<T>>
			{
				new ReplaceOneModel<T>(Builders<T>.Filter.Eq("_id", entity.Id), entity) { IsUpsert = true }
			};

			var collection = GetCollection<T>();
			await collection.BulkWriteAsync(bulkOps);

			return true;
		}


		private IMongoCollection<T> GetCollection<T>() where T : AbstractEntity
		{
			return _database.GetCollection<T>(GetCollectionName<T>());
		}

		private string GetCollectionName<T>() where T : AbstractEntity
		{			
			return typeof(T).Name;
		}
	}
}
