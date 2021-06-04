using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository
{
    public class PackageRepository : RepositoryBase<Package>,IPackage
    {
        public PackageRepository(RepositorySQL inyecction) : base(inyecction) { }
        public IEnumerable<PackageDTO> GetAll()
        {
            try
            {
                _RepositorySQL.conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM PACKAGE", _RepositorySQL.conn);
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    List<PackageDTO> listPackages = new List<PackageDTO>();

                    foreach (DataRow item in dt.Rows)
                    {
                        PackageDTO package = DTtoPackageDTO(item);
                        listPackages.Add(package);
                    }
                    return listPackages;
                }
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                _RepositorySQL.conn.Close();
            }
        }

        public List<PackageDTO> Get_PackageByDescription(string packageDescription)
        {
            try
            {
                string query = GetPackageQueryDescription(packageDescription);
                _RepositorySQL.conn.Open();
                SqlCommand command = new SqlCommand(query, _RepositorySQL.conn);
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    List<PackageDTO> listPackages = new List<PackageDTO>();

                    foreach (DataRow item in dt.Rows)
                    {
                        PackageDTO package = DTtoPackageDTO(item);
                        listPackages.Add(package);
                    }
                    return listPackages;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                _RepositorySQL.conn.Close();
            }
            return null;
        }

        public PackageDTO Get_PackageById(long idPackage)
        {
            try
            {
                SqlCommand command; SqlDataAdapter da;
                string query = GetPackageQueryId(idPackage);
                if(_RepositorySQL.conn.State == ConnectionState.Open)
                {
                    command = new SqlCommand(query, _RepositorySQL.conn);
                    da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                            return DTtoPackageDTO(item);
                    }
                    return null;
                }
                else
                {
                    _RepositorySQL.conn.Open();
                    command = new SqlCommand(query, _RepositorySQL.conn);
                    da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                            return DTtoPackageDTO(item);
                    }
                    _RepositorySQL.conn.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        private PackageDTO DTtoPackageDTO(DataRow item)
        {
            PackageDTO package = new PackageDTO();
            package.TravelPackageId = (long)item["ID"];
            package.Description = item["Description"].ToString();
            package.Products = GetPackageProducts(package.TravelPackageId);

            return package;
        }

        public List<ProductDTO> GetPackageProducts(long idPackage)
        {
            try
            {
                List<ProductDTO> listProducts = new List<ProductDTO>();
                string query = GetPackageDetailsQuery(idPackage);

                SqlCommand command = new SqlCommand(query, _RepositorySQL.conn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ProductDTO product = new ProductDTO();
                    product.ProductId = (long)row["idProduct"];
                    product.Description = row["ProductDescription"].ToString();
                    product.ProductType = row["TypeDescription"].ToString();
                    product.Category = string.IsNullOrEmpty(row["Category"].ToString()) == true ? 0 : (int)row["Category"];
                    float price = 0;
                    float.TryParse(row["Price"].ToString(), out price);
                    product.Price = price;

                    listProducts.Add(product);
                }
                return listProducts;
            }
            catch
            {
                return null;
            }
        }

        #region Queries

        private string GetPackageDetailsQuery(long idPackage)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"SELECT P.ID IdProduct,P.Description ProductDescription,P.TypeID,P.Category,T.Description TypeDescription, p.Price");
            sb.AppendLine($"FROM PRODUCT P INNER JOIN PRODUCT_TYPE T ON T.ID = P.TypeID WHERE P.PACKAGEID = {idPackage}");
            return sb.ToString();
        }

        private string GetPackageQueryDescription(string packageDescription)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT * FROM Package");
            sb.AppendLine($"WHERE Description LIKE '%{packageDescription}%'");

            return sb.ToString();
        }

        private string GetPackageQueryId(long id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT * FROM Package");
            sb.AppendLine($"WHERE ID = {id}");

            return sb.ToString();
        }

        #endregion
    }
}
