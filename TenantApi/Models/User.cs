using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TenantApi.Models
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
