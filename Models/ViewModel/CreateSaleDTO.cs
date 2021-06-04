using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class CreateSaleDTO
    {
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public long ClientID { get; set; }
        public long SalesmanID { get; set; }
        public int Passengers { get; set; }
        public float Commission { get; set; }
        public int AmountOfNights { get; set; }

    }
}
