using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Interfaces
{
    public interface IControlRepository : IRepository<Control>
    {
        Task<Control> Createe(Control control);
    }
}
