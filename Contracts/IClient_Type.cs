using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IClient_Type:IRepositoryBase<Client_Type>
    {
        public List<ClientTypeDTO> Get_ClientTypes();
    }
}
