using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracts
{
    public abstract class APackageTravel
    {
        private string _Hotel;
        private string _Car;
        private string _PlaneTicket;
        private int _Passangers;
        public string Hotel { get => _Hotel; set => _Hotel = value; }
        public string Car { get => _Car; set => _Car = value; }
        public string PlaneTicket { get => _PlaneTicket; set => _PlaneTicket = value; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only Numbers allowed.")]
        public int Passengers { get=> _Passangers; set=> _Passangers=value; }
    }
}
