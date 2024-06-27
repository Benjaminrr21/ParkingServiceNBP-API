using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs
{
    public class NewVehicleDTO
    {
        public string Mark { get; set; }
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public OwnerDTO Owner { get; set; }
    }
}
