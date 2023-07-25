using Common.Models;

namespace Common
{
    public interface IGenericRepository
    {
        Task<List<T>> GetAll<T>() where T : AbstractEntity;
        void SaveOrUpdateAsync<T>(T instanceOfT) where T : AbstractEntity;
        void DeleteAsync<T>(T instanceOfT) where T : AbstractEntity;
    }
}