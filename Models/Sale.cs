using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Sale : ModelBase
    {
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public long ClientID { get; set; }
        public long SalesmanID { get; set; }
        public int Passengers { get; set; }
        public float Commission { get; set; }
    }
}
