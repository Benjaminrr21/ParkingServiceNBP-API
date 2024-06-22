using Microsoft.EntityFrameworkCore;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Infrastructure.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    //Genericki repozitorijum
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ParkDbContext dbContext;

        public Repository(ParkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<T> Create(T entity)
        {
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            //nalazimo objekat
            var entity = await dbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                dbContext.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Update(int id, T entity)
        {
            var existingEntity = await dbContext.Set<T>().FindAsync(id);
            if (existingEntity != null)
            {
                dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                await dbContext.SaveChangesAsync();
                return existingEntity;
            }
            return null; // Ili bacite izuzetak ili obradite ovo drugačije prema vašem scenariju
        }
    }
}
