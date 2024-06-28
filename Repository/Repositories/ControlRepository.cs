using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Infrastructure.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ControlRepository : Repository<Control>, IControlRepository
    {
        private readonly ParkDbContext dbContext;

        public ControlRepository(ParkDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        
    }
}
