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
    public class MakeRepositoryADO : IMakeRepository
    {
        public Make GetMake(string makeName)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@MakeName", makeName);

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

        public IEnumerable<Make> GetMakesForListItems()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                IEnumerable<Make> makes = cn.Query<Make>("GetMakes", commandType: CommandType.StoredProcedure);

                if (makes.Any())
                {
                    return makes;
                }
            }
            return null;
        }
    }
}
