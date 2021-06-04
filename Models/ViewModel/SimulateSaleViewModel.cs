using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class SimulateSaleViewModel
    {
        private string _FullName;
        private int _ClienteTypeID;//IdCliente_Type
        private string _TypeClient;//_TypeClient Corporative o indivual
        private int _Passengers;      
        private int _AmountOfNights;
        //private float _Commissions;
        private List<string> _PackageDescription = new List<string>();//Nos da la descripcion del travel 
        private string _Details;//Description"Detalles" de la tabla Product
        private int _CategoryCar;
        public int ClienteTypeID { get => _ClienteTypeID; set => _ClienteTypeID = value; }
        public string TypeClient { get => _TypeClient; set => _TypeClient = value; }
        public int Passengers { get => _Passengers; set => _Passengers = value; }    
        public int AmountOfNights { get => _AmountOfNights; set => _AmountOfNights = value; }
        //public float Commissions { get => _Commissions; set => _Commissions = value; }
        public List<string> PackageDescription { get => _PackageDescription; set => _PackageDescription = value; }
        public string Details { get => _Details; set => _Details = value; }
        public int CategoryCar { get => _CategoryCar; set => _CategoryCar = value; }
        public string FullName { get => _FullName; set => _FullName = value; }
    }
}
