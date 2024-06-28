using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkEasyNBP.Domain.Interfaces;
using ParkEasyNBP.Domain.Models;
using ParkEasyNBP.Infrastructure.SqlServer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ParkDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public UserRepository(ParkDbContext dbContext, UserManager<ApplicationUser> userManager) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            return await dbContext.Users.Where(s => s.Role == "User").ToListAsync();
        }
        

        public async Task<IEnumerable<ApplicationUser>> GetAllControllors()
        {

            return await dbContext.Users.Where(s => s.Role == "Controllor").ToListAsync();
        }


        public async Task<ApplicationUser?> GetById(string id)
        {
            //return await dbContext.Users.FirstOrDefaultAsync(s => s.Id.ToString() == id);
            var user =  await dbContext.Users.FirstOrDefaultAsync(s => s.Id== id);
            return user;

        }

   
    }
}
