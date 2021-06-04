using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models.ViewModel;
using System.Transactions;
using Contracts;

namespace Repository
{
    public class CommissionRepository : RepositoryBase<Commission>,ICommission
    {
        public CommissionRepository(RepositorySQL inyecction) : base(inyecction) { }
        //public CommissionRepository(RepositorySQL inyecction, IRepositoryWrapper local) : base(inyecction) { _repoWrapper = local; }
        public bool Save(CalculateCommissionRequestDTO request, IRepositoryWrapper _repoWrapper)
        {
            //Using TransactionScope
            try
            {

                CostAndCommission costAndCommission = CommissionAndAmountCalculate(request,_repoWrapper);


                CreateSaleDTO dto = new CreateSaleDTO();
                dto.Date = DateTime.Now;
                dto.Amount = costAndCommission.TotalCost;
                dto.Commission = costAndCommission.Commission;
                dto.ClientID = request.ClientTypeId;
                dto.Passengers = request.PassengersAmmount;
                dto.SalesmanID = 1; //TODO cambiar por el real
                dto.AmountOfNights = request.TripDuration;

                string saleQuery = SaveSaleQuery(dto);
                SqlCommand sqlCommand = new SqlCommand(saleQuery, _RepositorySQL.conn);
                _RepositorySQL.conn.Open();

                Decimal saleID = (Decimal)sqlCommand.ExecuteScalar();

                foreach (int id in request.TravelPackageIds)
                {
                    PackageDTO package = _repoWrapper.Package.Get_PackageById(id);
                    if (package == null)
                        return false;

                    string query = SaveSale_Package((long)saleID, package.TravelPackageId, dto.AmountOfNights);
                    SqlCommand cmd = new SqlCommand(query, _RepositorySQL.conn);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch(Exception ex)
            {
                // transaction.Rollback();
                return false;
            }
            finally
            {
                _RepositorySQL.conn.Close();
            }
        }
        public CostAndCommission CommissionAndAmountCalculate(CalculateCommissionRequestDTO request, IRepositoryWrapper _repoWrapper)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            foreach (int id in request.TravelPackageIds)
            {
                products.AddRange(_repoWrapper.Package.GetPackageProducts(id));
            }

            return CalculateAmount(request.ClientTypeId, products, request.PassengersAmmount, request.TripDuration);
        }
        private CostAndCommission CalculateAmount(int clientType, ICollection<ProductDTO> products, int passenger, int duration)
        {
            float totalCost = 0;
            CostAndCommission costAndCommission = new CostAndCommission();

            if (clientType == 2) //2 Corporate
            {
                foreach (ProductDTO p in products) //For every product (car hotel or airplane)
                {
                    //Categorys: 1 airplane, 2 car rental, 3 hotel
                    switch (p.Category)
                    {
                        case 1: //airplane 
                            totalCost += p.Price * 2;
                            break;

                        case 2: //car or hotel
                        case 3:
                            totalCost += p.Price * duration;
                            break;
                    }
                }
                costAndCommission.Commission = totalCost * 0.10f;
                costAndCommission.TotalCost = totalCost * passenger; ;
            }
            else if (clientType == 1) //1 Individual
            {
                foreach (ProductDTO p in products)
                {
                    switch (p.Category)
                    {
                        case 1: //airplane 
                            totalCost += (p.Price * 0.10f);
                            break;

                        case 2: //car
                            totalCost += (p.Price * 0.01f + 100 * p.Category);
                            break;

                        case 3: //hotel
                            if (duration < 6)
                                totalCost += (p.Price / 2);
                            else
                                totalCost += ((p.Price * duration) / 6);
                            break;
                    }
                }
                costAndCommission.Commission = totalCost;
                costAndCommission.TotalCost = totalCost * passenger; ;
            }
            else
            {
                throw new Exception("ClientType incorrect. Please contact to support team");
            }
            return costAndCommission;
        }
        private string SaveSaleQuery(CreateSaleDTO dto)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO DBO.Sale");
            sb.AppendLine("(Date, Amount, ClientID, SalesmanID, Passengers, Commissions, AmountOfNights)");
            sb.AppendLine($"VALUES ('{dto.Date.ToString("yyyy-MM-dd HH:mm:ss")}', {dto.Amount}, {dto.ClientID}, {dto.SalesmanID}, {dto.Passengers}, {dto.Commission.ToString().Replace(',', '.')}, {dto.AmountOfNights});");
            sb.AppendLine("SELECT SCOPE_IDENTITY()");
            return sb.ToString();
        }
        private string SaveSale_Package(long saleID, long packageID, int amountOfNights)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO DBO.Sale_Package");
            sb.AppendLine("(PackageID, SaleID)");
            sb.AppendLine($"VALUES ({packageID}, {saleID})");

            return sb.ToString();
        }
    }
}
