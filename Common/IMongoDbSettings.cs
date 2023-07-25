namespace Common
{
    public interface IMongoDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string TenantCollection { get; set; }
    }
}