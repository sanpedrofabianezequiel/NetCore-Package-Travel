using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISalesman: IRepositoryBase<Salesman>//La interfaz IRepositoryBase le estable las querys
    {
        public SalesmanDTO GetById(long id);
        public IEnumerable<SalesmanDTO> GetAll();
        public long Add(CreateSalesmanDTO entity);
        public bool Delete(long id);
    }
}
