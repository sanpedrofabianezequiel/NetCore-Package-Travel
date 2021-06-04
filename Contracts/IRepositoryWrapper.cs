using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IClient_Type Client_Type { get; }
        ICommission Commission { get; }
        IPackage Package { get; }
        ISalesman SalesMan { get; }
    }
}
