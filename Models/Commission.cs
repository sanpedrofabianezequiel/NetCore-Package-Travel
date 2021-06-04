using Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Commission: APackageTravel
    {
        public float Commissions { get; set; }
        public int AmountOfNights { get; set; }
        public string Description { get; set; }
        public Commission()
        {
            Hotel = string.Empty;
            Car = string.Empty;
            PlaneTicket = string.Empty;
            Passengers = 0;
        }
    }
}
