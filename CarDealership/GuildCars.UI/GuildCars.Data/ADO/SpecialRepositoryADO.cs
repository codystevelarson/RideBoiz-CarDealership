using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GuildCars.Data.ADO
{
    public class SpecialRepositoryADO : ISpecialRepository
    {
        public List<Special> GetSpecials()
        {
            List<Special> specials = new List<Special>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetSpecials", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        Special row = new Special();

                        row.SpecialId = (int)dr["SpecialId"];
                        row.SpecialName = dr["SpecialName"].ToString();
                        row.Description = dr["Description"].ToString();
                        row.ImageFileName = dr["ImageFileName"].ToString();

                        specials.Add(row);
                    }
                }
            }
            if(specials.Any())
            {
                return specials;
            }
            return null;
        }


        public Special GetSpecial(int id)
        {
            Special special = new Special();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@SpecialId", id);

                return cn.Query<Special>("GetSpecial", param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }



        public Special Add(Special special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@SpecialId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@SpecialName", special.SpecialName);
                parameters.Add("@Description", special.Description);
                parameters.Add("@ImageFileName", special.ImageFileName);
                
                cn.Execute("AddSpecial", param: parameters, commandType: CommandType.StoredProcedure);

                special.SpecialId = parameters.Get<int>("@SpecialId");
            }
            return special;
        }


        public void Delete(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SpecialId", id);
                cn.Execute("DeleteSpecial", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
