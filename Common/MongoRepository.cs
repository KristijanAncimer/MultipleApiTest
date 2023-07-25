using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MongoRepository : IGenericRepository
    {
        public Task<List<T>> GetAll<T>() where T : AbstractEntity
        {

        }
        public void SaveOrUpdateAsync<T>(T instanceOfT) where T : AbstractEntity
        {

        }
        public void DeleteAsync<T>(T instanceOfT) where T : AbstractEntity
        {

        }
    }
}
