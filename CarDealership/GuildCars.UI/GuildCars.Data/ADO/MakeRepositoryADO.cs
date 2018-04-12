using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GuildCars.Data.ADO
{
    public class MakeRepositoryADO : IMakeRepository
    {
        

        public Make GetMake(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@MakeId", id);

                return cn.Query<Make>("GetMake", param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }
        
        public List<Make> GetMakes()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Make> makes = cn.Query<Make>("GetMakes", commandType: CommandType.StoredProcedure).ToList();
                
                if (makes.Any())
                {
                    return makes;
                }
            }
            return null;
        }

        public Make Add(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@MakeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@MakeName", make.MakeName);
                parameters.Add("@UserId", make.UserId);

                cn.Execute("AddMake", param: parameters, commandType: CommandType.StoredProcedure);

                make.MakeId = parameters.Get<int>("@MakeId");
            }
            return make;
        }

        public Make GetMakeByModelId(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@ModelId", id);

                return cn.Query<Make>("GetMakeByModelId", param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }
    }
}
