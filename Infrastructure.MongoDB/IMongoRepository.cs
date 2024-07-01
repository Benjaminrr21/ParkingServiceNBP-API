using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Infrastructure.MongoDB
{
    public interface IMongoRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<T> Create(T entity);
        Task Update(string id, T entity);
        Task Delete(string id);


    }
}
