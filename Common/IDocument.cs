using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }
        DateTime CreatedAt { get; }
    }
}