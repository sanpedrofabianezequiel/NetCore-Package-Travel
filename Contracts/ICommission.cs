using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICommission: IRepositoryBase<Commission>
    {
        public bool Save(CalculateCommissionRequestDTO request,  IRepositoryWrapper _repoWrapper);
    }
}
