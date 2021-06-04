using System.Collections.Generic;

namespace Models
{
    public class CalculateCommissionRequestDTO
    {
        public int ClientTypeId { get; set; }
        public int PassengersAmmount { get; set; }
        public int TripDuration { get; set; }
        public ICollection<int> TravelPackageIds { get; set; }
    }
}
