using System.Collections.Generic;

namespace Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public virtual async IEnumerable<T> GetAll()
        {
            //dbset
            List<T>results = await dbSet.FindAsync(_ => true);
            return results.ToList();
        }

        public virtual T GetById(object id) 
        {
            var korisnik = dbSet.Find(p => p.Id == id).FirstOrDefault();
            return korisnik;
        }

        void Insert(T obj)
        {
            //dbset

        }
        void Update(T obj)
        {
            //dbset

        }
        void Delete(T obj)
        {
            //dbset

        }
    }



    //public interface IRepository
    //{
    //    Task<List<T>> GetAllAsync<T>() where T AbstractEntity;
    //}


    // Generic constraints in c#
}