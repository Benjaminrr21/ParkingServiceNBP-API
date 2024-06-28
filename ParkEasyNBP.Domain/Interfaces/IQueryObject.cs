using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Interfaces
{
    public class IQueryObject
    {
        public bool IsSortAscending { get; set; }
        public string SortBy { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        //public Dictionary<string, object> Filters { get; set; } // Dodata kolekcija filtera

    }
}
