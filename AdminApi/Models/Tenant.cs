using System.Reflection.Metadata;

namespace AdminApi.Models
{
    
    public class Tenant: Document
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public int maxUsersNumber { get; set; }
    }
}
