using Microsoft.AspNet.Identity.EntityFramework;
using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Interfaces
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<IEnumerable<ApplicationUser>> GetAllControllors();
        Task<ApplicationUser?> GetById(string id);
        Task<Vehicle> GetMyVehicle(string id); 
    }
}
