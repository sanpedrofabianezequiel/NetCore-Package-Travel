using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositorySQL _Inyection;
        private IClient_Type Client_Type;
        private ICommission Commission;
        private IPackage Package;
        private ISalesman SalesMan;
        public RepositoryWrapper() { _Inyection = new RepositorySQL(); }
        public RepositoryWrapper(RepositorySQL inyeccion) => _Inyection = inyeccion;
        IClient_Type IRepositoryWrapper.Client_Type
        {
            get
            {
                if (Client_Type == null)
                    Client_Type = new ClientRepository(_Inyection);
                return Client_Type;
            }
        }

        ICommission IRepositoryWrapper.Commission
        {
            get
            {

                if (Commission == null)
                    Commission = new CommissionRepository(_Inyection);
                return Commission;
            }
        }
        IPackage IRepositoryWrapper.Package
        {
            get
            {
                if (Package == null)
                    Package = new PackageRepository(_Inyection);
                return Package;
            }
        }
        ISalesman IRepositoryWrapper.SalesMan
        {
            get
            {
                if (SalesMan == null)
                    SalesMan = new SalesmanRepository(_Inyection);
                return SalesMan;
            }
        }
    }
}