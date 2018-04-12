using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GuildCars.Data.ADO
{
    public class StateRepositoryADO : IStateRepository
    {
        public List<State> GetStates()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<State> states = cn.Query<State>("GetStates", commandType: CommandType.StoredProcedure).ToList();

                if (states.Any())
                {
                    return states;
                }
            }
            return null;
        }

        public State GetState(string stateId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@StateId", stateId);

                return cn.Query<State>("GetState", param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        
    }
}
