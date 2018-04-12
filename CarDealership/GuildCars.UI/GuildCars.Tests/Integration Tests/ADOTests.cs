using Dapper;
using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Models.Enums;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests.Integration_Tests
{
    [TestFixture]
    public class ADOTests
    {
        [SetUp]
        public void Reset()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                cn.Execute("DBReset", commandType: CommandType.StoredProcedure);

            }
        }


        //Vehicles
        [Test]
        public void CanLoadAllVehicles()
        {
            var repo = new VehicleRepositoryADO();

            List<Vehicle> vehicles = repo.GetAll();

            Assert.AreEqual(5, vehicles.Count());
            Assert.AreEqual("00000000000000000", vehicles[0].VIN);
            Assert.AreEqual(true, vehicles[0].New);
            Assert.AreEqual(2018, vehicles[0].Year);
            Assert.AreEqual("Challenger", vehicles[0].Model.ModelName);
            Assert.AreEqual(7, vehicles[0].Model.ModelId);
            Assert.AreEqual("Dodge", vehicles[0].Model.Make.MakeName);
            Assert.AreEqual(3, vehicles[0].Model.Make.MakeId);
            Assert.AreEqual(BodyStyle.Car, vehicles[0].BodyStyle);
            Assert.AreEqual("White", vehicles[0].Color.ColorName);
            Assert.AreEqual(1, vehicles[0].Color.ColorId);
            Assert.AreEqual("Leather", vehicles[0].Interior.InteriorName);
            Assert.AreEqual(2, vehicles[0].Interior.InteriorId);
            Assert.AreEqual(Transmission.Automatic, vehicles[0].Transmission);
            Assert.AreEqual(34, vehicles[0].Mileage);
            Assert.AreEqual(26500.99m, vehicles[0].SalePrice);
            Assert.AreEqual(29999.99m, vehicles[0].MSRP);
            Assert.AreEqual("New 2018 Dodge Challenger, Automatic Transmission, White with Leather Interior. Only white one in the tri-state area! Act fast before this beauty is gone", vehicles[0].Description);
            Assert.AreEqual(true, vehicles[0].Featured);
            Assert.AreEqual(false, vehicles[0].Sold);
            Assert.AreEqual("2018challengerwhite.jpg", vehicles[0].ImageFileName);
        }

        [Test]
        public void CanLoadVehicle()
        {
            var repo = new VehicleRepositoryADO();

            Vehicle vehicle = repo.GetByVin("00000000000000000");

            Assert.IsNotNull(vehicle);
            Assert.AreEqual("00000000000000000", vehicle.VIN);
            Assert.AreEqual(true, vehicle.New);
            Assert.AreEqual(2018, vehicle.Year);
            Assert.AreEqual("Challenger", vehicle.Model.ModelName);
            Assert.AreEqual(7, vehicle.Model.ModelId);
            Assert.AreEqual("Dodge", vehicle.Model.Make.MakeName);
            Assert.AreEqual(3, vehicle.Model.Make.MakeId);
            Assert.AreEqual(BodyStyle.Car, vehicle.BodyStyle);
            Assert.AreEqual(1, vehicle.Color.ColorId);
            Assert.AreEqual("White", vehicle.Color.ColorName);
            Assert.AreEqual(2, vehicle.Interior.InteriorId);
            Assert.AreEqual("Leather", vehicle.Interior.InteriorName);
            Assert.AreEqual(Transmission.Automatic, vehicle.Transmission);
            Assert.AreEqual(34, vehicle.Mileage);
            Assert.AreEqual(26500.99m, vehicle.SalePrice);
            Assert.AreEqual(29999.99m, vehicle.MSRP);
            Assert.AreEqual("New 2018 Dodge Challenger, Automatic Transmission, White with Leather Interior. Only white one in the tri-state area! Act fast before this beauty is gone", vehicle.Description);
            Assert.AreEqual(true, vehicle.Featured);
            Assert.AreEqual(false, vehicle.Sold);
            Assert.AreEqual("2018challengerwhite.jpg", vehicle.ImageFileName);
        }

        [Test]
        public void CanLoadOnlyUsedVehicles()
        {
            var repo = new VehicleRepositoryADO();

            List<Vehicle> vehicles = repo.GetAllUsed();

            Assert.AreEqual(2, vehicles.Count());
            Assert.AreEqual(2, vehicles.Where(v => v.New == false).Count());
        }

        [Test]
        public void CanLoadOnlyNewVehicles()
        {
            var repo = new VehicleRepositoryADO();

            List<Vehicle> vehicles = repo.GetAllNew();

            Assert.AreEqual(3, vehicles.Count());
            Assert.AreEqual(3, vehicles.Where(v => v.New == true).Count());
        }

        [Test]
        public void CanLoadOnlyFeaturedVehicles()
        {
            var repo = new VehicleRepositoryADO();

            List<Vehicle> vehicles = repo.GetAllFeatured();

            Assert.AreEqual(2, vehicles.Count());
            Assert.AreEqual(2, vehicles.Where(v => v.Featured == true).Count());
        }

        [TestCase("99999999999999999",true, 2018, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg")]
        public void CanAddVehicle(string vin, bool condition, int year, int modleId, BodyStyle bodyStyle, int colorId, int interiorId, Transmission transmission, int mileage, decimal salePrice, decimal msrp, string description, bool featured, bool sold, string imageFileName)
        {
            
            Vehicle vehicle = new Vehicle
            {
                VIN = vin,
                New = condition,
                Year = year,
                BodyStyle = bodyStyle,
                Transmission = transmission,
                Mileage = mileage,
                SalePrice = salePrice,
                MSRP = msrp,
                Description = description,
                Featured = featured,
                Sold = sold,
                ImageFileName = imageFileName,
                Model = new CarModel
                {
                    ModelId = modleId
                },
                Color = new Color
                {
                    ColorId = colorId
                },
                Interior = new Interior
                {
                    InteriorId = interiorId
                }
            };

            var repo = new VehicleRepositoryADO();

            Vehicle newVehicle = repo.Add(vehicle);

            Assert.AreEqual(newVehicle.VIN, vehicle.VIN);
            Assert.AreEqual(newVehicle.New, vehicle.New);
            Assert.AreEqual(newVehicle.Year, vehicle.Year);
            Assert.AreEqual(newVehicle.Model.ModelId, vehicle.Model.ModelId);
            Assert.AreEqual(newVehicle.Color.ColorId, vehicle.Color.ColorId);
            Assert.AreEqual(newVehicle.Interior.InteriorId, vehicle.Interior.InteriorId);
            Assert.AreEqual(newVehicle.BodyStyle, vehicle.BodyStyle);
            Assert.AreEqual(newVehicle.Transmission, vehicle.Transmission);
            Assert.AreEqual(newVehicle.Mileage, vehicle.Mileage);
            Assert.AreEqual(newVehicle.SalePrice, vehicle.SalePrice);
            Assert.AreEqual(newVehicle.MSRP, vehicle.MSRP);
            Assert.AreEqual(newVehicle.Description, vehicle.Description);
            Assert.AreEqual(newVehicle.Featured, vehicle.Featured);
            Assert.AreEqual(newVehicle.Sold, vehicle.Sold);
            Assert.AreEqual(newVehicle.ImageFileName, vehicle.ImageFileName);
        }



        [TestCase("99999999999999999", true, 2018, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg")]
        public void CanEditVehicle(string vin, bool condition, int year, int modleId, BodyStyle bodyStyle, int colorId, int interiorId, Transmission transmission, int mileage, decimal salePrice, decimal msrp, string description, bool featured, bool sold, string imageFileName)
        {
            var repo = new VehicleRepositoryADO();

            Vehicle oldVehicle = new Vehicle
            {
                VIN = "99999999999999999",
                New = false,
                Year = 2002,
                BodyStyle = BodyStyle.SUV,
                Transmission = Transmission.Automatic,
                Mileage = 200000,
                SalePrice = 4000,
                MSRP = 7000,
                Description = "Old car",
                Featured = false,
                Sold = false,
                ImageFileName = "oldcar.jpg",
                Model = new CarModel
                {
                    ModelId = 1
                },
                Color = new Color
                {
                    ColorId = 1
                },
                Interior = new Interior
                {
                    InteriorId = 1
                }
            };

            Vehicle addedOldVehicle = repo.Add(oldVehicle);

            Vehicle editVehicle = new Vehicle
            {
                VIN = vin,
                New = condition,
                Year = year,
                BodyStyle = bodyStyle,
                Transmission = transmission,
                Mileage = mileage,
                SalePrice = salePrice,
                MSRP = msrp,
                Description = description,
                Featured = featured,
                Sold = sold,
                ImageFileName = imageFileName,
                Model = new CarModel
                {
                    ModelId = modleId
                },
                Color = new Color
                {
                    ColorId = colorId
                },
                Interior = new Interior
                {
                    InteriorId = interiorId
                }
            };


            Vehicle editedVehicle = repo.Edit(editVehicle);

            Assert.AreEqual(editedVehicle.VIN, addedOldVehicle.VIN);
            Assert.AreEqual(editedVehicle.VIN, editVehicle.VIN);
            Assert.AreEqual(editedVehicle.New, editVehicle.New);
            Assert.AreEqual(editedVehicle.Year, editVehicle.Year);
            Assert.AreEqual(editedVehicle.Model.ModelId, editVehicle.Model.ModelId);
            Assert.AreEqual(editedVehicle.Color.ColorId, editVehicle.Color.ColorId);
            Assert.AreEqual(editedVehicle.Interior.InteriorId, editVehicle.Interior.InteriorId);
            Assert.AreEqual(editedVehicle.BodyStyle, editVehicle.BodyStyle);
            Assert.AreEqual(editedVehicle.Transmission, editVehicle.Transmission);
            Assert.AreEqual(editedVehicle.Mileage, editVehicle.Mileage);
            Assert.AreEqual(editedVehicle.SalePrice, editVehicle.SalePrice);
            Assert.AreEqual(editedVehicle.MSRP, editVehicle.MSRP);
            Assert.AreEqual(editedVehicle.Description, editVehicle.Description);
            Assert.AreEqual(editedVehicle.Featured, editVehicle.Featured);
            Assert.AreEqual(editedVehicle.Sold, editVehicle.Sold);
            Assert.AreEqual(editedVehicle.ImageFileName, editVehicle.ImageFileName);
        }

        [TestCase("00000000000000004", true)]
        public void CanDeleteVehicle(string vin, bool expected)
        {
            bool actual = false;
            var repo = new VehicleRepositoryADO();

            var vehicle = repo.GetByVin(vin);

            repo.Delete(vin);

            var nullVehicle = repo.GetByVin(vin);

            if (vehicle.VIN != null && nullVehicle.VIN == null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }



        [Test]
        public void CanSearchVehiclesByMinYear()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.Search(new VehicleSearchParameters { MinYear = 2017 });

            Assert.AreEqual(3, vehicles.Count());
            
        }

        [Test]
        public void CanSearchVehiclesByMaxYear()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.Search(new VehicleSearchParameters { MaxYear = 2014 });

            Assert.AreEqual(2, vehicles.Count());

        }


        [Test]
        public void CanSearchVehiclesByMinPrice()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.Search(new VehicleSearchParameters { MinPrice = 25000 });

            Assert.AreEqual(2, vehicles.Count());

        }

        [Test]
        public void CanSearchVehiclesByMaxPrice()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.Search(new VehicleSearchParameters { MaxPrice = 20000 });

            Assert.AreEqual(2, vehicles.Count());

        }

        [Test]
        public void CanSearchVehiclesByNew()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.Search(new VehicleSearchParameters { View = "New" });

            Assert.AreEqual(3, vehicles.Count());

        }

        [Test]
        public void CanSearchVehiclesByUsed()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.Search(new VehicleSearchParameters { View = "Used" });

            Assert.AreEqual(2, vehicles.Count());

        }

        [Test]
        public void CanSearchVehiclesByModel()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.Search(new VehicleSearchParameters { VehicleSearch = "Cha" });

            Assert.AreEqual(2, vehicles.Count());

        }

        [Test]
        public void CanSearchVehiclesByMake()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.Search(new VehicleSearchParameters { VehicleSearch = "Do" });

            Assert.AreEqual(2, vehicles.Count());

        }

        [Test]
        public void CanSearchVehiclesByYear()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.Search(new VehicleSearchParameters { VehicleSearch = "2014" });

            Assert.AreEqual(1, vehicles.Count());

        }


        //Sale Item
        [TestCase("00000000000000000", "Test", "Larson", "test@test.com", "5555555", "555 Test Street", "#3", "MN", "Testapolis", 55303, 25050.43, 1, "16c72667-a76c-4337-9107-06ea9c553983", true)]
        public void CanAddSaleItem(string vin, string firstName, string lastName, string email, string phone, string street1, string street2, string stateId, string city, int zip, decimal purchasePrice, PurchaseType purchaseType, string userId,bool expected)
        {
            bool actual = false;

            SaleItem saleItem = new SaleItem
            {
                VIN = vin,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Street1 = street1,
                Street2 = street2,
                StateId = stateId,
                City = city,
                Zipcode = zip,
                PurchasePrice = purchasePrice,
                PurchaseType = purchaseType,
                UserId = userId
            };

            var repo = new SaleItemRepositoryADO();

            SaleItem addedItem = repo.Add(saleItem);

            if (addedItem.SaleId != 0)
            {
                actual = true;
            }

            Assert.AreEqual(actual, expected);
        }



        //States
        [Test]
        public void CanLoadStates()
        {
            var repo = new StateRepositoryADO();

            List<State> states = repo.GetStates();

            Assert.AreEqual(51, states.Count());
        }

        [TestCase("xx", false)]
        [TestCase("", false)]
        [TestCase("xxxxxxxx", false)]
        [TestCase("MN", true)]
        public void CanLoadStateById(string stateId, bool expected)
        {
            bool actual = false;
            var repo = new StateRepositoryADO();

            State state = repo.GetState(stateId);

            if(state != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }





        //Models
        [Test]
        public void CanLoadModels()
        {
            var repo = new CarModelRepositoryADO();

            List<CarModel> models = repo.GetModels();

            Assert.AreEqual(30, models.Count());
            Assert.AreEqual(1, models[0].ModelId);
            Assert.AreEqual(1, models[0].Make.MakeId);
            Assert.AreEqual("Ford", models[0].Make.MakeName);
            Assert.AreEqual("Focus", models[0].ModelName);
            Assert.AreEqual("Chuck@Testa.com", models[0].UserName);
            Assert.IsNotNull(models[0].DateAdded);
        }


        [TestCase(1000, false)]
        [TestCase(1, true)]
        public void CanLoadModelById(int id, bool expected)
        {
            bool actual = false;

            var repo = new CarModelRepositoryADO();

            CarModel model = repo.GetModel(id);

            if(model != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void CanLoadModesByMakeId()
        {
            var repo = new CarModelRepositoryADO();

            List<CarModel> models = repo.GetModelsByMakeId(1);

            Assert.IsNotNull(models);
            Assert.AreEqual(3, models.Count());
        }


        [TestCase("Test", "57383afa-9157-4d24-86cf-2e1a097b29f4", "Chuck@Testa.com", 1, "Ford", true)]
        public void CanAddModel(string name, string userId, string userName, int makeId, string makeName, bool expected)
        {
            bool actual = false;

            var repo = new CarModelRepositoryADO();

            Make make = new Make
            {
                MakeId = makeId,
                MakeName = makeName
            };

            CarModel newModel = new CarModel
            {
                ModelName = name,
                UserId = userId,
                UserName = userName,
                Make = make
            };

            CarModel model = repo.Add(newModel);
            if(model.ModelId != 0)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(name, model.ModelName);
            Assert.AreEqual(userId, model.UserId);
            Assert.AreEqual(userName, model.UserName);
            Assert.AreEqual(makeId, model.Make.MakeId);
            Assert.AreEqual(makeName, model.Make.MakeName);
        }



        //Makes
        [Test]
        public void CanLoadMakes()
        {
            var repo = new MakeRepositoryADO();

            List<Make> makes = repo.GetMakes();

            Assert.AreEqual(10, makes.Count());
            Assert.IsNotNull(makes[0].DateAdded);
            Assert.AreEqual(1, makes[0].MakeId);
            Assert.AreEqual("Ford", makes[0].MakeName);
            Assert.AreEqual("Chuck@Testa.com", makes[0].UserName);
        }

        [TestCase(1000, false)]
        [TestCase(1, true)]
        public void CanLoadMakeByName(int id, bool expected)
        {
            bool actual = false;

            var repo = new MakeRepositoryADO();

            Make make = repo.GetMake(id);

            if(make != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);

        }


        [Test]
        public void CanLoadMakeByModelId()
        {
            var repo = new MakeRepositoryADO();

            var make = repo.GetMakeByModelId(2);

            Assert.IsNotNull(make);
            Assert.AreEqual("Ford", make.MakeName);
            Assert.AreEqual(1, make.MakeId);

        }


        [TestCase("Test", "57383afa-9157-4d24-86cf-2e1a097b29f4", "Chuck@Testa.com", true)]
        public void CanAddMake(string name, string userId, string userName, bool expected)
        {
            bool actual = false;

            var repo = new MakeRepositoryADO();

            Make newMake = new Make
            {
                MakeName = name,
                UserId = userId,
                UserName = userName
            };

            Make make = repo.Add(newMake);

            if (make.MakeId != 0)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(name, make.MakeName);
            Assert.AreEqual(userId, make.UserId);
            Assert.AreEqual(userName, make.UserName);
            Assert.IsNotNull(make.DateAdded);
        }



        //Specials
        [Test]
        public void CanLoadSpecials()
        {
            var repo = new SpecialRepositoryADO();

            List<Special> specials = repo.GetSpecials();

            Assert.AreEqual(10, specials.Count());
            Assert.AreEqual("Summer Sale", specials[0].SpecialName);
            Assert.AreEqual(1, specials[0].SpecialId);
            Assert.AreEqual("No money down, no payments until next summer! SAY WHAT?! Yeah, you heard us. When you can't beat the heat, you can't beat these prices!", specials[0].Description);
            Assert.AreEqual("summersale.jpg", specials[0].ImageFileName);
        }

        [TestCase(1, true)]
        [TestCase(1000, false)]
        public void CanLoadSpecialById(int id, bool expected)
        {
            bool actual = false;

            var repo = new SpecialRepositoryADO();

            Special special = repo.GetSpecial(id);

            if (special != null && special.SpecialId == id)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }


        [TestCase("Test", "This is a Test", "Test.jpg", true)]
        public void CanAddSpecial(string name, string description, string image, bool expected)
        {
            var repo = new SpecialRepositoryADO();

            bool actual = false;

            Special newSpecial = new Special
            {
                SpecialName = name,
                Description = description,
                ImageFileName = image
            };

            Special special = repo.Add(newSpecial);
            if (special.SpecialId != 0)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(name, special.SpecialName);
            Assert.AreEqual(description, special.Description);
            Assert.AreEqual(image, special.ImageFileName);
        }



        [TestCase("00000000000000000", "Test", "Tester", "test@test.com", "5555555", "Test Message", true)]
        public void CanAddContact(string vin, string firstName, string lastName, string email, string phone, string message, bool expected)
        {
            bool actual = false;

            Contact contact = new Contact
            {
                VIN = vin,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Message = message
            };

            var repo = new ContactRepositoryADO();
            contact = repo.Add(contact);

            if (contact.ContactId != 0)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(vin, contact.VIN);
            Assert.AreEqual(firstName, contact.FirstName);
            Assert.AreEqual(lastName, contact.LastName);
            Assert.AreEqual(email, contact.Email);
            Assert.AreEqual(phone, contact.Phone);
            Assert.AreEqual(message, contact.Message);

        }



        [Test]
        public void CanLoadNewInventoryReport()
        {
            var repo = new VehicleRepositoryADO();
            var report = repo.InventoryNew();

            Assert.AreEqual(2, report.Count());
        }


        [Test]
        public void CanLoadUsedInventoryReport()
        {
            var repo = new VehicleRepositoryADO();
            var report = repo.InventoryUsed();

            Assert.AreEqual(2, report.Count());
        }

    }
}
