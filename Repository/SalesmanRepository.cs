using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository
{
    public class SalesmanRepository : RepositoryBase<Salesman>, ISalesman
    {
        public SalesmanRepository(RepositorySQL inyecction) : base(inyecction)  { }
        public SalesmanDTO GetById(long id)
        {
            string query = GetSalesmanQuery(id);
            SqlCommand command = new SqlCommand(query, _RepositorySQL.conn);
            try
            {
                _RepositorySQL.conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    SalesmanDTO dto = new SalesmanDTO();
                    dto.ID = long.Parse(reader["ID"].ToString());
                    dto.FullName = reader["FullName"].ToString();
                    dto.UserName = reader["UserName"].ToString();

                    DateTime startDate;
                    if (DateTime.TryParse(reader["StartDate"].ToString(), out startDate))
                    {
                        dto.StartDate = startDate;
                    }
                    else
                    {
                        throw new Exception($"Error parsing StartDate for {typeof(Salesman)}: {dto.FullName}.");
                    }
                    return dto;
                }
            }
            finally
            {
                _RepositorySQL.conn.Close();
            }
            return null;
        }
        public IEnumerable<SalesmanDTO> GetAll()
        {
            List<SalesmanDTO> list = new List<SalesmanDTO>();

            string query = this.GetSalesmanQuery();
            SqlCommand command = new SqlCommand(query, _RepositorySQL.conn);
            try
            {
                _RepositorySQL.conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SalesmanDTO dto = new SalesmanDTO();
                    dto.ID = long.Parse(reader["ID"].ToString());
                    dto.FullName = reader["FullName"].ToString();
                    dto.UserName = reader["UserName"].ToString();

                    DateTime startDate;
                    if (DateTime.TryParse(reader["StartDate"].ToString(), out startDate))
                    {
                        dto.StartDate = startDate;
                    }
                    else
                    {
                        throw new Exception($"Error parsing StartDate for {typeof(Salesman)}: {dto.FullName}.");
                    }
                    list.Add(dto);
                }
            }
            finally
            {
                _RepositorySQL.conn.Close();
            }
            return list;
        }
        public long Add(CreateSalesmanDTO entity)
        {
            string query = this.CreateSalesmanQuery(entity);
            SqlCommand command = new SqlCommand(query, _RepositorySQL.conn);
            try
            {
                _RepositorySQL.conn.Open();
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                _RepositorySQL.conn.Close();
            }
        }
        public bool Delete(long id)
        {
            if (SalesmanHasSales(id))
            {
                return false;
            }

            string query = GetDeleteSalesmanQuery(id);
            SqlCommand command = new SqlCommand(query, _RepositorySQL.conn);
            try
            {
                _RepositorySQL.conn.Open();
                int affectedLines = command.ExecuteNonQuery();
                if (affectedLines > 0)
                {
                    return true;
                }
            }
            finally
            {
                _RepositorySQL.conn.Close();
            }

            return false;
        }
        private bool SalesmanHasSales(long id)
        {
            string query = GetSalesmanHasSalesQuery(id);
            SqlCommand command = new SqlCommand(query, _RepositorySQL.conn);
            try
            {
                _RepositorySQL.conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows == true)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                _RepositorySQL.conn.Close();
            }
        }
        #region Querys
        private string CreateSalesmanQuery(CreateSalesmanDTO salesman)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO DBO.Salesman");
            sb.AppendLine("(FullName, UserName, StartDate, IsActive, IsAdmin, Password)");
            sb.AppendLine($"VALUES ('{salesman.FullName}', '{salesman.UserName}',");
            sb.AppendLine($"'{salesman.StartDate.ToString("yyyy-MM-dd")}', '{salesman.IsActive}',");
            sb.AppendLine($"'{salesman.IsAdmin}', '{salesman.Password}')");
            return sb.ToString();
        }
        private string GetSalesmanQuery(long id = 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ID, FullName, UserName, StartDate, IsActive, IsAdmin ");
            sb.AppendLine("FROM DBO.Salesman s");
            sb.AppendLine($"WHERE s.IsActive = 1");
            if (id != 0)
            {
                sb.AppendLine($"AND s.ID = {id}");
            }
            return sb.ToString();
        }
        private string GetSalesmanHasSalesQuery(long id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT TOP 1 sale.ID");
            sb.AppendLine("FROM DBO.Salesman man WITH(nolock)");
            sb.AppendLine("INNER JOIN DBO.Sale sale WITH(nolock)");
            sb.AppendLine("     ON man.ID = sale.SalesmanID");
            sb.AppendLine($"WHERE man.ID = {id}");
            return sb.ToString();
        }
        private string GetDeleteSalesmanQuery(long id)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("DELETE FROM DBO.Salesman");
            sb.AppendLine("UPDATE DBO.Salesman");
            sb.AppendLine("SET IsActive = 0");
            sb.Append($"WHERE ID = {id}");

            return sb.ToString();
        }
        #endregion



    }
}