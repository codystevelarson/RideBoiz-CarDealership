using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Data;
using System.Data.SqlClient;

namespace GuildCars.Data.ADO
{
    public class SaleItemRepositoryADO : ISaleItemRepository
    {
        public SaleItem Add(SaleItem saleItem)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@SaleId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@VIN", saleItem.VIN);
                parameters.Add("@UserId", saleItem.UserId);
                parameters.Add("@FirstName", saleItem.FirstName);
                parameters.Add("@LastName", saleItem.LastName);
                if (!string.IsNullOrEmpty(saleItem.Email))
                {
                    parameters.Add("@Email", saleItem.Email);
                }
                else
                {
                    parameters.Add("@Email", null);
                }
                if (!string.IsNullOrEmpty(saleItem.Phone))
                {
                    parameters.Add("@Phone", saleItem.Phone);
                }
                else
                {
                    parameters.Add("@Phone", null);
                }
                parameters.Add("@Street1", saleItem.Street1);
                parameters.Add("@Street2", saleItem.Street2);
                parameters.Add("@StateId", saleItem.StateId);
                parameters.Add("@City", saleItem.City);
                parameters.Add("@Zipcode", saleItem.Zipcode);
                parameters.Add("@PurchasePrice", saleItem.PurchasePrice);
                parameters.Add("@PurchaseType", saleItem.PurchaseType);

                cn.Execute("AddSaleItem", param: parameters, commandType: CommandType.StoredProcedure);

                saleItem.SaleId = parameters.Get<int>("@SaleId");
            }
            return saleItem;
        }
    }
}
