using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Infrastructure.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OneOffCardRepository : Repository<OneOffCard>, IOneOffCardRepository
    {
        private readonly ParkDbContext dbContext;

        public OneOffCardRepository(ParkDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<OneOffCard> Create(OneOffCard p)
        {
            p.DateTimeSelling = DateTime.Now;
            p.Period = DateTime.Now.AddDays(1);
            await dbContext.AddAsync(p);
            await dbContext.SaveChangesAsync();
            return p;
        }


    }
}
