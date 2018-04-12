using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Enums;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GuildCars.Data.ADO
{
    public class VehicleRepositoryADO : IVehicleRepository
    {

        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();
                        row.Model = new CarModel();
                        row.Model.Make = new Make();
                        row.Color = new Color();
                        row.Interior = new Interior();

                        row.VIN = dr["VIN"].ToString();
                        row.New = (bool)dr["New"];
                        row.Year = (int)dr["Year"];
                        row.Model.Make.MakeId = (int)dr["MakeId"];
                        row.Model.Make.MakeName = dr["MakeName"].ToString();
                        row.Model.ModelId = (int)dr["ModelId"];
                        row.Model.ModelName = dr["ModelName"].ToString();
                        row.BodyStyle = (BodyStyle)dr["BodyStyle"];
                        row.Color.ColorId = (int)dr["ColorId"];
                        row.Color.ColorName = dr["ColorName"].ToString();
                        row.Interior.InteriorId = (int)dr["InteriorId"];
                        row.Interior.InteriorName = dr["InteriorName"].ToString();
                        row.Transmission = (Transmission)dr["Transmission"];
                        row.Mileage = (int)dr["Mileage"];
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.Description = dr["Description"].ToString();
                        row.Featured = (bool)dr["Featured"];
                        row.Sold = (bool)dr["Sold"];
                        row.ImageFileName = dr["ImageFileName"].ToString();

                        vehicles.Add(row);
                    }
                    if (vehicles.Any())
                    {
                        return vehicles;
                    }
                }
            }
            return null;
        }

        public List<Vehicle> GetAllFeatured()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();

                        row.VIN = dr["VIN"].ToString();
                        row.New = (bool)dr["New"];
                        row.Year = (int)dr["Year"];
                        row.Model.Make.MakeId = (int)dr["MakeId"];
                        row.Model.Make.MakeName = dr["MakeName"].ToString();
                        row.Model.ModelId = (int)dr["ModelId"];
                        row.Model.ModelName = dr["ModelName"].ToString();
                        row.BodyStyle = (BodyStyle)dr["BodyStyle"];
                        row.Color.ColorId = (int)dr["ColorId"];
                        row.Color.ColorName = dr["ColorName"].ToString();
                        row.Interior.InteriorId = (int)dr["InteriorId"];
                        row.Interior.InteriorName = dr["InteriorName"].ToString();
                        row.Transmission = (Transmission)dr["Transmission"];
                        row.Mileage = (int)dr["Mileage"];
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.Description = dr["Description"].ToString();
                        row.Featured = (bool)dr["Featured"];
                        row.Sold = (bool)dr["Sold"];
                        row.ImageFileName = dr["ImageFileName"].ToString();

                        vehicles.Add(row);
                    }
                    if (vehicles.Any())
                    {
                        return vehicles;
                    }
                }
            }
            return null;
        }

        public List<Vehicle> GetAllNew()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllNew", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();

                        row.VIN = dr["VIN"].ToString();
                        row.New = (bool)dr["New"];
                        row.Year = (int)dr["Year"];
                        row.Model.Make.MakeId = (int)dr["MakeId"];
                        row.Model.Make.MakeName = dr["MakeName"].ToString();
                        row.Model.ModelId = (int)dr["ModelId"];
                        row.Model.ModelName = dr["ModelName"].ToString();
                        row.BodyStyle = (BodyStyle)dr["BodyStyle"];
                        row.Color.ColorId = (int)dr["ColorId"];
                        row.Color.ColorName = dr["ColorName"].ToString();
                        row.Interior.InteriorId = (int)dr["InteriorId"];
                        row.Interior.InteriorName = dr["InteriorName"].ToString();
                        row.Transmission = (Transmission)dr["Transmission"];
                        row.Mileage = (int)dr["Mileage"];
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.Description = dr["Description"].ToString();
                        row.Featured = (bool)dr["Featured"];
                        row.Sold = (bool)dr["Sold"];
                        row.ImageFileName = dr["ImageFileName"].ToString();

                        vehicles.Add(row);
                    }
                    if (vehicles.Any())
                    {
                        return vehicles;
                    }
                }
            }
            return null;
        }

        public List<Vehicle> GetAllUsed()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsed", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();

                        row.VIN = dr["VIN"].ToString();
                        row.New = (bool)dr["New"];
                        row.Year = (int)dr["Year"];
                        row.Model.Make.MakeId = (int)dr["MakeId"];
                        row.Model.Make.MakeName = dr["MakeName"].ToString();
                        row.Model.ModelId = (int)dr["ModelId"];
                        row.Model.ModelName = dr["ModelName"].ToString();
                        row.BodyStyle = (BodyStyle)dr["BodyStyle"];
                        row.Color.ColorId = (int)dr["ColorId"];
                        row.Color.ColorName = dr["ColorName"].ToString();
                        row.Interior.InteriorId = (int)dr["InteriorId"];
                        row.Interior.InteriorName = dr["InteriorName"].ToString();
                        row.Transmission = (Transmission)dr["Transmission"];
                        row.Mileage = (int)dr["Mileage"];
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.Description = dr["Description"].ToString();
                        row.Featured = (bool)dr["Featured"];
                        row.Sold = (bool)dr["Sold"];
                        row.ImageFileName = dr["ImageFileName"].ToString();

                        vehicles.Add(row);
                    }
                    if (vehicles.Any())
                    {
                        return vehicles;
                    }
                }
            }
            return null;
        }

        public Vehicle GetByVin(string vin)
        {
            Vehicle vehicle = new Vehicle();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VIN", vin);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.New = (bool)dr["New"];
                        vehicle.Year = (int)dr["Year"];
                        vehicle.Model.Make.MakeId = (int)dr["MakeId"];
                        vehicle.Model.Make.MakeName = dr["MakeName"].ToString();
                        vehicle.Model.ModelId = (int)dr["ModelId"];
                        vehicle.Model.ModelName = dr["ModelName"].ToString();
                        vehicle.BodyStyle = (BodyStyle)dr["BodyStyle"];
                        vehicle.Color.ColorId = (int)dr["ColorId"];
                        vehicle.Color.ColorName = dr["ColorName"].ToString();
                        vehicle.Interior.InteriorId = (int)dr["InteriorId"];
                        vehicle.Interior.InteriorName = dr["InteriorName"].ToString();
                        vehicle.Transmission = (Transmission)dr["Transmission"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.Featured = (bool)dr["Featured"];
                        vehicle.Sold = (bool)dr["Sold"];
                        vehicle.ImageFileName = dr["ImageFileName"].ToString();
                    }
                }

                return vehicle;
            }
        }

        public Vehicle Add(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("AddVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@New", vehicle.New);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.Model.ModelId);
                cmd.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);
                cmd.Parameters.AddWithValue("@ColorId", vehicle.Color.ColorId);
                cmd.Parameters.AddWithValue("@InteriorId", vehicle.Interior.InteriorId);
                cmd.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@Sold", vehicle.Sold);
                cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
            return vehicle;
        }

        public Vehicle Edit(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("EditVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@New", vehicle.New);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.Model.ModelId);
                cmd.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);
                cmd.Parameters.AddWithValue("@ColorId", vehicle.Color.ColorId);
                cmd.Parameters.AddWithValue("@InteriorId", vehicle.Interior.InteriorId);
                cmd.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@Sold", vehicle.Sold);
                cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
            return vehicle;
        }

        public void Delete(string vin)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VIN", vin);
                cn.Execute("DeleteVehicle", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Vehicle> Search(VehicleSearchParameters parameters)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = cn
                };


                string query = "SELECT TOP 20 v.VIN, v.New, v.[Year],ma.MakeId, ma.MakeName, mo.ModelId, mo.ModelName, v.BodyStyle, c.ColorId, c.ColorName, i.InteriorId, i.InteriorName, v.Transmission, v.Mileage, v.SalePrice, v.MSRP, v.[Description], v.Featured, v.Sold, v.ImageFileName " +
                    "FROM Vehicles v " +
                    "INNER JOIN Models mo ON mo.ModelId = v.ModelId " +
                    "INNER JOIN Makes ma ON ma.MakeId = mo.MakeId " +
                    "INNER JOIN Colors c ON c.ColorId = v.ColorId " +
                    "INNER JOIN Interiors i ON i.InteriorId = v.InteriorId " +
                    "WHERE 1 = 1";

                if (!string.IsNullOrEmpty(parameters.View))
                {
                    if (parameters.View == "New")
                    {
                        query += "AND v.New = 1 ";
                    }
                    else if (parameters.View == "Used")
                    {
                        query += "AND v.New = 0 ";
                    }
                    else if (parameters.View == "Sales" || parameters.View == "Admin")
                    {
                        query += "AND v.Sold = 0 ";
                    }
                }

                if (parameters.MinPrice.HasValue)
                {
                    query += "AND v.SalePrice >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    if (parameters.MaxPrice == 200000)
                    {
                        query += "AND v.SalePrice >= @MaxPrice ";
                        cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                    }
                    else
                    {
                        query += "AND v.SalePrice <= @MaxPrice ";
                        cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                    }

                }

                if (parameters.MinYear.HasValue)
                {
                    query += "AND v.Year >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }

                if (parameters.MaxYear.HasValue)
                {
                    query += "AND v.Year <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }

                if (!string.IsNullOrEmpty(parameters.VehicleSearch))
                {
                    query += "AND v.Year LIKE @Year ";
                    cmd.Parameters.AddWithValue("@Year", parameters.VehicleSearch + "%");

                    query += "OR ma.MakeName LIKE @MakeName ";
                    cmd.Parameters.AddWithValue("@MakeName", parameters.VehicleSearch + "%");

                    query += "OR mo.ModelName LIKE @ModelName ";
                    cmd.Parameters.AddWithValue("ModelName", parameters.VehicleSearch + "%");
                }

                if (parameters.View == "New")
                {
                    query += "ORDER BY v.MSRP DESC ";
                }

                if (parameters.View == "Used")
                {
                    query += "ORDER BY v.MSRP DESC ";
                }

                if (parameters.View == "Report")
                {
                    query += "ORDER BY v.Year, ma.MakeName, mo.ModelName";
                }

                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();


                        row.VIN = dr["VIN"].ToString();
                        row.New = (bool)dr["New"];
                        row.Year = (int)dr["Year"];
                        row.Model.Make.MakeId = (int)dr["MakeId"];
                        row.Model.Make.MakeName = dr["MakeName"].ToString();
                        row.Model.ModelId = (int)dr["ModelId"];
                        row.Model.ModelName = dr["ModelName"].ToString();
                        row.BodyStyle = (BodyStyle)dr["BodyStyle"];
                        row.Color.ColorId = (int)dr["ColorId"];
                        row.Color.ColorName = dr["ColorName"].ToString();
                        row.Interior.InteriorId = (int)dr["InteriorId"];
                        row.Interior.InteriorName = dr["InteriorName"].ToString();
                        row.Transmission = (Transmission)dr["Transmission"];
                        row.Mileage = (int)dr["Mileage"];
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.Description = dr["Description"].ToString();
                        row.Featured = (bool)dr["Featured"];
                        row.Sold = (bool)dr["Sold"];
                        row.ImageFileName = dr["ImageFileName"].ToString();

                        vehicles.Add(row);
                    }
                    if (vehicles.Any())
                    {
                        return vehicles;
                    }
                }
            }
            return null;
        }

        public List<InventoryReport> InventoryNew()
        {
            List<InventoryReport> reports = new List<InventoryReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InventoryReportNew", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport report = new InventoryReport();

                        report.Year = (int)dr["Year"];
                        report.Count = (int)dr["Count"];
                        report.StockValue = (decimal)dr["StockValue"];
                        report.Make = dr["MakeName"].ToString();
                        report.Model = dr["ModelName"].ToString();

                        reports.Add(report);
                    }
                }
                return reports;
            }
        }

        public List<InventoryReport> InventoryUsed()
        {
            List<InventoryReport> reports = new List<InventoryReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InventoryReportUsed", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport report = new InventoryReport();

                        report.Year = (int)dr["Year"];
                        report.Count = (int)dr["Count"];
                        report.StockValue = (decimal)dr["StockValue"];
                        report.Make = dr["MakeName"].ToString();
                        report.Model = dr["ModelName"].ToString();

                        reports.Add(report);
                    }
                }
                return reports;
            }
        }
    }
}
