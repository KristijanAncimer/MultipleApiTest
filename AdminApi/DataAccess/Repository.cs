using AdminApi.Commands;
using AdminApi.Models;
using MongoDB.Driver;

namespace AdminApi.DataAccess
{
    public class Repository : IRepository
    {
        private readonly string ConnectionString = "mongodb://mamongo:27017";
        private readonly string DatabaseName = "TenantsDatabase";
        private readonly string TenantCollection = "tenants";
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }
        public async Task<Tenant> CreateTenantAsync(CreateTenantCmd cmd)
        {
            var tenant = new Tenant
            {
                Id = Guid.NewGuid(),
                Name = cmd.Name,
                maxUsersNumber = cmd.maxUsersNumber
            };

            var client = ConnectToMongo<Tenant>(TenantCollection);
            await client.InsertOneAsync(tenant);

            return tenant;
        }

        public async Task<List<Tenant>> GetAllAsync()
        {
            var usersCollection = ConnectToMongo<Tenant>(TenantCollection);
            var results = await usersCollection.FindAsync(_ => true);
            return results.ToList();
        }
    }
}


