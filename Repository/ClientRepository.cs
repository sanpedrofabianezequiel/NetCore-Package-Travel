using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClientRepository : RepositoryBase<Client_Type>,IClient_Type
    {
        public ClientRepository(RepositorySQL inyecction) : base(inyecction) { }
        public List<ClientTypeDTO> Get_ClientTypes()
        {
            try
            {
                _RepositorySQL.conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM CLIENT_TYPE", _RepositorySQL.conn);
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    List<ClientTypeDTO> list = new List<ClientTypeDTO>();

                    foreach (DataRow row in dt.Rows)
                    {
                        ClientTypeDTO item = new ClientTypeDTO();
                        item.ClientTypeId = (int)row["ID"];
                        item.Description = row["Type"].ToString();

                        list.Add(item);
                    }

                    return list;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _RepositorySQL.conn.Close();
            }
        }
    }
}
