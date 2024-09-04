using ParkEasyNBP.Domain.Interfaces;

namespace ParkEasyNBP.API.Mediator.Query
{
    public class PenaltyQueryObject : IQueryObject
    {
        public decimal Price { get; set; }
        public bool IsSortAscending { get; set; }
        public string SortBy { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
