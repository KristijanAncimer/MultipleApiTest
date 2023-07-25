using System.Collections.Generic;

namespace Common
{
	public class GenericRepository:IGenericRepository
    {
        public Task<List<T>> GetAll<T>()
        {
            //dbset
            List<T>results = await dbSet.FindAsync(_ => true);
            return results.ToList();
        }

        public void SaveOrUpdateAsync<T>(T instanceOfT)
        {
            //dbset

        }
        public void DeleteAsync(T instanceOfT)
        {

        }
    }



    //public interface IRepository
    //{
    //    Task<List<T>> GetAllAsync<T>() where T AbstractEntity;
    //}


    // Generic constraints in c#
}