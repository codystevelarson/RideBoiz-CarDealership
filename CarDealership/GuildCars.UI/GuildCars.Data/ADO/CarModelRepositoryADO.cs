using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GuildCars.Data.ADO
{
    public class CarModelRepositoryADO : ICarModelRepository
    {
        public CarModel GetModel(int id)
        {
            CarModel model = new CarModel();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {            

                SqlCommand cmd = new SqlCommand("GetModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ModelId", id);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        model.Make = new Make();

                        model.ModelId = (int)dr["ModelId"];
                        model.ModelName = dr["ModelName"].ToString();
                        model.Make.MakeId = (int)dr["MakeId"];
                        model.Make.MakeName = dr["MakeName"].ToString();
                        model.DateAdded = (DateTime)dr["DateAdded"];
                        model.UserName = dr["UserName"].ToString();
                        model.UserId = dr["UserId"].ToString();
                    }
                }
            }
            if (model.ModelId == 0)
            {
                return null;
            }
            return model;
        }

        public List<CarModel> GetModels()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<CarModel> models = new List<CarModel>();

                SqlCommand cmd = new SqlCommand("GetModels", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        CarModel row = new CarModel();
                        row.Make = new Make();

                        row.ModelId = (int)dr["ModelId"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.Make.MakeId = (int)dr["MakeId"];
                        row.Make.MakeName = dr["MakeName"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.UserName = dr["UserName"].ToString();
                        row.UserId = dr["UserId"].ToString();

                        models.Add(row);
                    }
                }
                    if (models.Any())
                    {
                        return models;
                    }
            }
            return null;
        }

        public CarModel Add(CarModel model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();


                parameters.Add("@ModelId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@ModelName", model.ModelName);
                parameters.Add("@UserId", model.UserId);
                parameters.Add("@MakeId", model.Make.MakeId);

                cn.Execute("AddModel", param: parameters, commandType: CommandType.StoredProcedure);

                model.ModelId = parameters.Get<int>("@ModelId");
            }
            return model;
        }

        public List<CarModel> GetModelsByMakeId(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<CarModel> models = new List<CarModel>();

                SqlCommand cmd = new SqlCommand("GetModelsByMakeId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeId", id);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CarModel row = new CarModel();
                        row.Make = new Make();

                        row.ModelId = (int)dr["ModelId"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.Make.MakeId = (int)dr["MakeId"];
                        row.Make.MakeName = dr["MakeName"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.UserName = dr["UserName"].ToString();
                        row.UserId = dr["UserId"].ToString();

                        models.Add(row);
                    }
                }
                if (models.Any())
                {
                    return models;
                }
            }
            return null;
        }
    }
}
