using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;
using TenantApi.Commands;
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

        public async Task<User> CreateUserAsync(CreateUserCmd cmd)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = cmd.Name,
            };

            var usersCollection = ConnectToMongo<User>(UserCollection);
            await usersCollection.InsertOneAsync(user);

            return user;
        }

        public void DeleteUser(User user)
        {
            var usersCollection = ConnectToMongo<User>(UserCollection);
            usersCollection.DeleteOneAsync(p => p.Id == user.Id);
        }

        public async Task<User> GetById(Guid id)
        {
            var usersCollection = ConnectToMongo<User>(UserCollection);
            var korisnik = usersCollection.Find(p => p.Id == id).FirstOrDefault();
            return korisnik;

            //var usersCollection = ConnectToMongo<User>(UserCollection);
            //var results = await usersCollection.FindAsync(_ =>_.Id==id);
            //return results.ToList();
        }

        //public Task UpdateUser(User user)
        //{
        //    var usersCollection = ConnectToMongo<User>(UserCollection);
        //    return usersCollection.FindOneAndUpdate();

        //}
    }
}
