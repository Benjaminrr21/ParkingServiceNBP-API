using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Interfaces
{
    public interface IPenaltyRepository : IRepository<Penalty>
    {
        Task<Penalty> RemovePenalty(int id, string reason);
        Task<IEnumerable<Penalty>> GetPenaltiesOfVehicle(int vid);
    }
}
