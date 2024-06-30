using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Infrastructure.MongoDB
{
    public interface IMongoRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task<List<T>> GetAll();

    }
}
