using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Models
{
    public class Controllor : ApplicationUser
    {
        public int Id { get; set; }
        public string Namee { get; set; }
        public Zone Zone { get; set; }
        public int ZoneId { get; set; }


    }
}
