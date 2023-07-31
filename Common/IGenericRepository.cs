using Common.Models;

namespace Common
{
    public interface IGenericRepository
    {
        IQueryable<T> GetAll<T>() where T : AbstractEntity;

        Task<bool> SaveOrUpdateAsync<T>(T entity) where T : AbstractEntity;
		Task<bool> DeleteAsync<T>(T entity) where T : AbstractEntity;
		Task<bool> DeleteAsync<T>(Guid entityId) where T : AbstractEntity;
	}
}