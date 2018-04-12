using GuildCars.Data.Interfaces;
using GuildCars.Models.Enums;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.TestRepos
{
    public class VehicleRepositoryTEST : IVehicleRepository
    {
        private static List<Vehicle> _vehicles;

        public VehicleRepositoryTEST()
        {
            Color white = new Color { ColorId = 1, ColorName = "White" };
            Color black = new Color { ColorId = 2, ColorName = "Black" };
            Color red = new Color { ColorId = 3, ColorName = "Red" };
            Color green = new Color { ColorId = 4, ColorName = "Green" };
            Color blue = new Color { ColorId = 5, ColorName = "Blue" };
            Color purple = new Color { ColorId = 6, ColorName = "Purple" };
            Color orange = new Color { ColorId = 7, ColorName = "Orange" };
            Color yellow = new Color { ColorId = 8, ColorName = "Yellow" };
            Color pink = new Color { ColorId = 9, ColorName = "Pink" };
            Color lime = new Color { ColorId = 10, ColorName = "Lime" };

            Interior cloth = new Interior { InteriorId = 1, InteriorName = "Cloth" };
            Interior leather = new Interior { InteriorId = 2, InteriorName = "Leather" };
            Interior suede = new Interior { InteriorId = 3, InteriorName = "Suede" };
            Interior velvet = new Interior { InteriorId = 4, InteriorName = "Velvet" };
            Interior walnut = new Interior { InteriorId = 5, InteriorName = "Walnut" };
            Interior creme = new Interior { InteriorId = 6, InteriorName = "Creme" };
            Interior mink = new Interior { InteriorId = 7, InteriorName = "Mink" };
            Interior alligator = new Interior { InteriorId = 8, InteriorName = "Alligator" };
            Interior gucci = new Interior { InteriorId = 9, InteriorName = "Gucci" };
            Interior custom = new Interior { InteriorId = 10, InteriorName = "Custom" };

            Make ford = new Make { MakeId = 1, MakeName = "Ford", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" };
            Make chevy = new Make { MakeId = 2, MakeName = "Chevy", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" };
            Make dodge = new Make { MakeId = 3, MakeName = "Dodge", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" };
            Make saturn = new Make { MakeId = 4, MakeName = "Saturn", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" };
            Make kia = new Make { MakeId = 5, MakeName = "Kia", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" };

            CarModel focus = new CarModel { ModelId = 1, ModelName = "Focus", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = ford };
            CarModel f150 = new CarModel { ModelId = 2, ModelName = "F150", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = ford };
            CarModel challenger = new CarModel { ModelId = 3, ModelName = "Challenger", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = dodge };
            CarModel charger = new CarModel { ModelId = 4, ModelName = "Charger", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = dodge };
            CarModel cruze = new CarModel { ModelId = 5, ModelName = "Cruze", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = chevy };
            CarModel silverado = new CarModel { ModelId = 6, ModelName = "Silverado", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = chevy };
            CarModel vue = new CarModel { ModelId = 7, ModelName = "VUE", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = saturn };
            CarModel ion = new CarModel { ModelId = 8, ModelName = "ION", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = saturn };
            CarModel sorento = new CarModel { ModelId = 9, ModelName = "Sorento", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = kia };
            CarModel optima = new CarModel { ModelId = 10, ModelName = "Optima", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = kia };

            _vehicles = new List<Vehicle>
            {
                new Vehicle { VIN = "00000000000000001", Year = 2018, Model = focus, Color = yellow, Interior = cloth, BodyStyle = BodyStyle.Car, Transmission = Transmission.Automatic, Mileage = 103, SalePrice = 15000.99m, MSRP = 17000.99m, Description = "Focus Test", ImageFileName = "focus.jpg", Featured = true, New = true, Sold = false },
                new Vehicle { VIN = "00000000000000002", Year = 2001, Model = f150, Color = black, Interior = leather, BodyStyle = BodyStyle.Truck, Transmission = Transmission.Automatic, Mileage = 102354, SalePrice = 12999.99m, MSRP = 14499.99m, Description = "F150 Test", ImageFileName = "f150.jpg", Featured = false, New = false, Sold = false },
                new Vehicle { VIN = "00000000000000003", Year = 2011, Model = challenger, Color = white, Interior = custom, BodyStyle = BodyStyle.Car, Transmission = Transmission.Manual, Mileage = 74353, SalePrice = 19000, MSRP = 22000, Description = "Challenger Test", ImageFileName = "challenger.jpg", Featured = false, New = false, Sold = true },
                new Vehicle { VIN = "00000000000000004", Year = 2018, Model = charger, Color = lime, Interior = mink, BodyStyle = BodyStyle.Car, Transmission = Transmission.Manual, Mileage = 21, SalePrice = 30000.00m, MSRP = 34499.98m, Description = "Charger Test", ImageFileName = "charger.jpg", Featured = true, New = true, Sold = false },
                new Vehicle { VIN = "00000000000000005", Year = 2014, Model = cruze, Color = blue, Interior = walnut, BodyStyle = BodyStyle.Car, Transmission = Transmission.Automatic, Mileage = 66745, SalePrice = 7849.99m, MSRP = 17000.99m, Description = "Cruze Test", ImageFileName = "cruze.jpg", Featured = true, New = false, Sold = false },

            };
        }


        public Vehicle Add(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
            return vehicle;
        }

        public void Delete(string vin)
        {
            Vehicle vehicle = _vehicles.SingleOrDefault(v => v.VIN == vin);
            _vehicles.Remove(vehicle);
        }

        public Vehicle Edit(Vehicle vehicle)
        {
            Vehicle edit = _vehicles.SingleOrDefault(v => v.VIN == vehicle.VIN);
            _vehicles.Remove(edit);
            edit = vehicle;
            _vehicles.Add(edit);
            return edit;
        }

        public List<Vehicle> GetAll()
        {
            return _vehicles;
        }

        public List<Vehicle> GetAllFeatured()
        {
            return _vehicles.Where(v => v.Featured == true).ToList();
        }

        public List<Vehicle> GetAllNew()
        {
            return _vehicles.Where(v => v.New == true).ToList();
        }

        public List<Vehicle> GetAllUsed()
        {
            return _vehicles.Where(v => v.New == false).ToList();
        }

        public Vehicle GetByVin(string vin)
        {
            return _vehicles.SingleOrDefault(v => v.VIN == vin);
        }

        public List<InventoryReport> InventoryNew()
        {
            //nightmare linq statment
            throw new NotImplementedException();
        }

        public List<InventoryReport> InventoryUsed()
        {
            //nightmare linq statment
            throw new NotImplementedException();
        }

        public List<Vehicle> Search(VehicleSearchParameters parameters)
        {
            //How?
            throw new NotImplementedException();
        }
    }
}
