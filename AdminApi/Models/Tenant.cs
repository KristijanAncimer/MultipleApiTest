using Common.Models;
using MongoDB.Bson.Serialization.Attributes;
using System.Reflection.Metadata;

namespace AdminApi.Models
{
    
    public class Tenant: AbstractEntity
    {       
       public int MaxUsersNumber { get; set; }
    }
}
