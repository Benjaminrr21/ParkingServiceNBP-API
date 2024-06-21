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
            var users = await userManager.Users.ToListAsync();
            var usersList = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Contains("User"))
                {
                    usersList.Add(user);
                }
            }

            return usersList;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllControllors()
        {
          
                var users = await userManager.Users.ToListAsync();
                var usersList = new List<ApplicationUser>();

                foreach (var user in users)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles.Contains("Controllor"))
                    {
                        usersList.Add(user);
                    }
                }

                return usersList;
        }
    }
}
