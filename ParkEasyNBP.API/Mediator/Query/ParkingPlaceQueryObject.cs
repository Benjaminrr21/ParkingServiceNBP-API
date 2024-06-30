using ParkEasyNBP.Domain.Interfaces;

namespace ParkEasyNBP.API.Mediator.Query
{
    public class ParkingPlaceQueryObject : IQueryObject
    {
<<<<<<< HEAD
        public string Status { get; set; } 
=======
        /*public string Status { get; set; } // "Free" ili "Occupied"
>>>>>>> 41bca3407fa8d61fd9081a06f73d4c31d280a861
        public string Street { get; set; }
        public int Id { get; set; }*/
        public string Name { get; set; }
        public bool IsSortAscending { get; set; }
        public string SortBy { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
