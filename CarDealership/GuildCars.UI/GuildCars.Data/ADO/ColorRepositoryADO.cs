using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GuildCars.Data.ADO
{
    public class ColorRepositoryADO : IColorRepository
    {
        public Color Get(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@ColorId", id);

                return cn.Query<Color>("GetColor",param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public List<Color> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<Color>("GetColors", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
