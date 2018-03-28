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



    }
}
