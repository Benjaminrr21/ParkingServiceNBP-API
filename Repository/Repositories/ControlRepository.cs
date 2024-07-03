using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ParkEasyNBP.Infrastructure.SqlServer;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ControlRepository : Repository<Control>, IControlRepository
    {
        private readonly ParkDbContext dbContext;
        public IPenaltyRepository penalty { get; set; }

        public ControlRepository(ParkDbContext dbContext, IPenaltyRepository penalty) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.penalty = penalty;
        }
        public async Task<Control> Createe(Control control)
        {
            //Vehicle v = await dbContext.Vehicles.Include(c => c.OneOffCards).FirstOrDefaultAsync(c => c.Id == control.VehicleId);
            OneOffCard oc = await dbContext.OneOffCards.FirstOrDefaultAsync(c => c.VehicleId == control.VehicleId);
            SubscriptionCard sc = await dbContext.SubscriptionCards.FirstOrDefaultAsync(c => c.VehicleId == control.VehicleId);
            if(oc!=null && oc.Period < DateTime.Now)
            {
                await penalty.Create(new Penalty()
                {
                    Why = "Nevazeca jednokratna karta.",
                    Price = 1200,
                    DateTime = DateTime.Now,
                    VehicleId = control.VehicleId
                });
                control.IsPenalty = true;
            }
            if (sc != null && sc.Period < DateTime.Now)
            {
                await penalty.Create(new Penalty()
                {
                    Why = "Nevazeca pretplatna karta.",
                    Price = 3200,
                    DateTime = DateTime.Now,
                    VehicleId = control.VehicleId
                });
                control.IsPenalty = true;
            }
            else
            {
                control.IsPenalty = false;
            }
                await dbContext.AddAsync(control);
                await dbContext.SaveChangesAsync();
                return control;
            
        }

        
    }
}
