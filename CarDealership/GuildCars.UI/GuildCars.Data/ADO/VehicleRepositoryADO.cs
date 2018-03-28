using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class VehicleRepositoryADO : IVehicleRepository
    {

        public List<Vehicle> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Vehicle> vehicles = cn.Query<Vehicle>("GetAllVehicles", commandType: CommandType.StoredProcedure).ToList();

                if (vehicles.Any())
                {
                    return vehicles;
                }
            }
            return null;
        }

        public List<Vehicle> GetAllFeatured()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Vehicle> vehicles = cn.Query<Vehicle>("GetAllFeatured", commandType: CommandType.StoredProcedure).ToList();

                if (vehicles.Any())
                {
                    return vehicles;
                }
            }
            return null;
        }

        public List<Vehicle> GetAllNew()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Vehicle> vehicles = cn.Query<Vehicle>("GetAllNew", commandType: CommandType.StoredProcedure).ToList();
                if(vehicles.Any())
                {
                    return vehicles;
                }
            }
            return null;
        }

        public List<Vehicle> GetAllUsed()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Vehicle> vehicles = cn.Query<Vehicle>("GetAllUsed", commandType: CommandType.StoredProcedure).ToList();

                if (vehicles.Any())
                {
                    return vehicles;
                }
            }
            return null;
        }

        public Vehicle GetByVin(string vin)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@VIN", vin);

                return cn.Query<Vehicle>("GetVehicle", param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }
    }
}
