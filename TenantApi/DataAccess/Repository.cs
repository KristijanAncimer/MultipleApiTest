using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;
using TenantApi.Models;

namespace TenantApi.DataAccess
{
    public class Repository : IRepository
    {
        private readonly string ConnectionString = "mongodb://mamongo:27017";
        private readonly string DatabaseName = "UsersDatabase";
        private readonly string UserCollection = "users";
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }
        public async Task<List<User>> GetAllUsers()
        {
            var usersCollection = ConnectToMongo<User>(UserCollection);
            var results = await usersCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public Task CreateUser(User user)
        {
            var usersCollection = ConnectToMongo<User>(UserCollection);
            return usersCollection.InsertOneAsync(user);
        }

        public void DeleteUser(User user)
        {
            var usersCollection = ConnectToMongo<User>(UserCollection);
            usersCollection.DeleteOneAsync(p => p.Name == user.Name);
        }
    }
}
