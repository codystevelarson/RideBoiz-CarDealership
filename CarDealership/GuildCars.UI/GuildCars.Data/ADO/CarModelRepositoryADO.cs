using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class CarModelRepositoryADO : ICarModelRepository
    {
        public CarModel GetModel(string modelName)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@ModelName", modelName);

                return cn.Query<CarModel>("GetModel", param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public List<CarModel> GetModels()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<CarModel> models = cn.Query<CarModel>("GetModels", commandType: CommandType.StoredProcedure).ToList();

                if(models.Any())
                {
                    return models;
                }
            }
            return null;
        }
    }
}
