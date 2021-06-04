using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPackage:IRepositoryBase<Package>
    {
        public List<ProductDTO> GetPackageProducts(long idPackage);
        public PackageDTO Get_PackageById(long idPackage);
        public List<PackageDTO> Get_PackageByDescription(string packageDescription);
        public IEnumerable<PackageDTO> GetAll();
    }
}
