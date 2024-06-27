using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
//using Microsoft.EntityFrameworkCore;
using ParkEasyNBP.Infrastructure.SqlServer;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SubscriptionCardRepository : Repository<SubscriptionCard>, ISubscriptionCardRepository
    {
        private readonly ParkDbContext dbContext;

        public SubscriptionCardRepository(ParkDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
       
        public async Task<SubscriptionCard> Create(SubscriptionCard p)
        {
            p.Period = DateTime.Now.AddMonths(1);
            await dbContext.AddAsync(p);
            await dbContext.SaveChangesAsync();
            return p;
        }
    }
}
