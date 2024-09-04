using ParkEasyNBP.Domain.Interfaces;

namespace ParkEasyNBP.API.Mediator.Query
{
    public class ParkingPlaceQueryObject : IQueryObject
    {
        public string Status { get; set; }
        public bool IsSortAscending { get; set; }
        public string SortBy { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
