using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GuildCars.Data.ADO
{
    public class InteriorRepositoryADO : IInteriorRepository
    {
        public Interior Get(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@InteriorId", id);

                return cn.Query<Interior>("GetInterior", param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public List<Interior> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<Interior>("GetInteriors", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
