using GuildCars.BLL.Factories;
using GuildCars.Models.Enums;
using GuildCars.Models.Tables;
using NUnit.Framework;

namespace GuildCars.BLL.Tests
{
    [TestFixture]
    public class MangerTests
    {
        [Test]
        public void MOCKCanGetAllCarModels()
        {
            var manager = CarModelManagerFactory.Create();

            var response = manager.GetAll();

            Assert.AreEqual(true, response.Success);
        }

        [TestCase(1, true)]
        [TestCase(0, false)]
        public void MOCKCanGetModelByMakeId(int id, bool expected)
        {
            var manager = CarModelManagerFactory.Create();

            var response = manager.GetModelsByMakeId(id);

            Assert.AreEqual(expected, response.Success);
        }


        [TestCase("TestModel", 1, "TestUser", "UserId", true)]
        [TestCase("", 1, "TestUser", "UserId", false)]
        [TestCase("TestModel", 0, "TestUser", "UserId", false)]
        [TestCase("TestModel", 1, "", "UserId", false)]
        [TestCase("TestModel", 1, "TestUser", "", false)]
        public void MOCKCanAddModel(string modelName, int makeId, string username, string userId, bool expected)
        {
            var manager = CarModelManagerFactory.Create();

            var response = manager.Add(new CarModel { ModelName = modelName, Make = new Make { MakeId = makeId }, UserName = username, UserId = userId });

            Assert.AreEqual(expected, response.Success);
        }


        [Test]
        public void MOCKCanGetAllColors()
        {
            var manager = ColorManagerFactory.Create();

            var response = manager.GetAll();

            Assert.AreEqual(true, response.Success);
        }


        [TestCase(1, true)]
        [TestCase(0, false)]
        public void MOCKCanGetColorById(int id, bool expected)
        {
            var manager = ColorManagerFactory.Create();

            var response = manager.Get(id);

            Assert.AreEqual(expected, response.Success);
        }


        [TestCase("00000000000000001", "Test", "Tester", "test@test.com", "5555555", "Test Message", true)]
        [TestCase("0000000000000000", "Test", "Tester", "test@test.com", "5555555", "Test Message", false)]
        [TestCase("00000000000000001", "", "Tester", "test@test.com", "5555555", "Test Message", false)]
        [TestCase("00000000000000001", "Test", "", "test@test.com", "5555555", "Test Message", false)]
        [TestCase("00000000000000001", "Test", "Tester", "", "5555555", "Test Message", true)]
        [TestCase("00000000000000001", "Test", "Tester", "test@test.com", "", "Test Message", true)]
        [TestCase("00000000000000001", "Test", "Tester", "test@test.com", "5555555", "", false)]
        [TestCase("00000000000000001", "Test", "Tester", "", "", "Test Message", false)]
        public void MOCKCanAddContact(string vin, string firstName, string lastName, string email, string phone, string message, bool expected)
        {
            Contact contact = new Contact
            {
                VIN = vin,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Message = message
            };

            var manager = ContactManagerFactory.Create();

            var response = manager.Add(contact);

            Assert.AreEqual(expected, response.Success);
        }


        [Test]
        public void MOCKCanGetAllInteriors()
        {
            var manager = InteriorManagerFactory.Create();

            var response = manager.GetAll();

            Assert.AreEqual(true, response.Success);
        }


        [TestCase(1, true)]
        [TestCase(0, false)]
        public void MOCKCanGetInteriorById(int id, bool expected)
        {
            var manager = InteriorManagerFactory.Create();

            var response = manager.Get(id);

            Assert.AreEqual(expected, response.Success);
        }


        [Test]
        public void MOCKCanGetAllMakes()
        {
            var manager = MakeManagerFactory.Create();

            var response = manager.GetAll();

            Assert.AreEqual(true, response.Success);
        }


        [TestCase("TestMake", "TestUser", "UserId", true)]
        [TestCase("", "TestUser", "UserId", false)]
        [TestCase("TestMake", "", "UserId", false)]
        [TestCase("TestMake", "TestUser", "", false)]
        public void MOCKCanAddMake(string makeName, string userName, string userId, bool expected)
        {
            Make make = new Make
            {
                MakeName = makeName,
                UserName = userName,
                UserId = userId
            };

            var manager = MakeManagerFactory.Create();

            var response = manager.Add(make);

            Assert.AreEqual(expected, response.Success);
        }


        [Test]
        public void MOCKCanGetAllSpecials()
        {
            var manager = SpecialManagerFactory.Create();

            var response = manager.GetAll();

            Assert.AreEqual(true, response.Success);
        }


        [TestCase(1, true)]
        [TestCase(0, false)]
        public void MOCKCanGetSpecialById(int id, bool expected)
        {
            var manager = SpecialManagerFactory.Create();

            var response = manager.Get(id);

            Assert.AreEqual(expected, response.Success);
        }

        [TestCase("Test Name", "Description", "test.jpg", true)]
        [TestCase("", "Description", "test.jpg", false)]
        [TestCase("Test Name", "", "test.jpg", false)]
        [TestCase("Test Name", "Description", "", false)]
        public void MOCKCanAddSpecial(string name, string description, string imageFileName, bool expected)
        {
            Special special = new Special
            {
                SpecialName = name,
                Description = description,
                ImageFileName = imageFileName
            };

            var manager = SpecialManagerFactory.Create();

            var response = manager.Add(special);

            Assert.AreEqual(expected, response.Success);
        }


        [Test]
        public void MOCKCanGetAllStates()
        {
            var manager = StateManagerFactory.Create();

            var response = manager.GetAll();

            Assert.AreEqual(true, response.Success);
        }


        [TestCase("MN", true)]
        [TestCase("--", false)]
        public void MOCKCanGetStateById(string id, bool expected)
        {
            var manager = StateManagerFactory.Create();

            var response = manager.Get(id);

            Assert.AreEqual(expected, response.Success);
        }


        [TestCase("00000000000000001", "Test", "Tester", "Test@Test.Com", "5555555", "123 Test St.", "#3", "MN", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", true)]
        [TestCase("0000000000000000", "Test", "Tester", "Test@Test.Com", "5555555", "123 Test St.", "#3", "MN", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", false)]
        [TestCase("00000000000000000", "Test", "Tester", "Test@Test.Com", "5555555", "123 Test St.", "#3", "MN", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", false)]
        [TestCase("00000000000000001", "", "Tester", "Test@Test.Com", "5555555", "123 Test St.", "#3", "MN", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", false)]
        [TestCase("00000000000000001", "Test", "", "Test@Test.Com", "5555555", "123 Test St.", "#3", "MN", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", false)]
        [TestCase("00000000000000001", "Test", "Tester", "", "", "123 Test St.", "#3", "MN", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", false)]
        [TestCase("00000000000000001", "Test", "Tester", "", "5555555", "123 Test St.", "#3", "MN", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", true)]
        [TestCase("00000000000000001", "Test", "Tester", "Test@Test.Com", "", "123 Test St.", "#3", "MN", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", true)]
        [TestCase("00000000000000001", "Test", "Tester", "Test@Test.Com", "5555555", "", "#3", "MN", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", false)]
        [TestCase("00000000000000001", "Test", "Tester", "Test@Test.Com", "5555555", "123 Test St.", "", "MN", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", true)]
        [TestCase("00000000000000001", "Test", "Tester", "Test@Test.Com", "5555555", "123 Test St.", "#3", "--", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", false)]
        [TestCase("00000000000000001", "Test", "Tester", "Test@Test.Com", "5555555", "123 Test St.", "#3", "MN", "", 55555, 14950.98, PurchaseType.BankFinance, "TestUser1", false)]
        [TestCase("00000000000000001", "Test", "Tester", "Test@Test.Com", "5555555", "123 Test St.", "#3", "MN", "Testapolis", 5555, 14950.98, PurchaseType.BankFinance, "TestUser1", false)]
        [TestCase("00000000000000001", "Test", "Tester", "Test@Test.Com", "5555555", "123 Test St.", "#3", "MN", "Testapolis", 55555, 14250, 0, "TestUser1", false)]
        [TestCase("00000000000000001", "Test", "Tester", "Test@Test.Com", "5555555", "123 Test St.", "#3", "MN", "Testapolis", 55555, 14950.98, PurchaseType.BankFinance, "", false)]
        public void MOCKCanAddSaleItem(string vin, string firstName, string lastName, string email, string phone, string street1, string street2, string stateId, string city, int zipcode, decimal purchasePrice, PurchaseType purchaseType, string userId, bool expected)
        {
            SaleItem sale = new SaleItem
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
                Zipcode = zipcode,
                PurchasePrice = purchasePrice,
                PurchaseType = purchaseType,
                UserId = userId
            };

            var manager = SaleItemManagerFactory.Create();

            var response = manager.Add(sale);

            Assert.AreEqual(expected, response.Success);
        }


        [Test]
        public void MOCKCanGetAllVehicles()
        {
            var manager = VehicleManagerFactory.Create();

            var response = manager.GetAll();

            Assert.AreEqual(true, response.Success);
        }


        [Test]
        public void MOCKCanGetAllNewVehicles()
        {
            var manager = VehicleManagerFactory.Create();

            var response = manager.GetAllNew();

            Assert.AreEqual(true, response.Success);
        }

        [Test]
        public void MOCKCanGetAllUsedVehicles()
        {
            var manager = VehicleManagerFactory.Create();

            var response = manager.GetAllUsed();

            Assert.AreEqual(true, response.Success);
        }

        [Test]
        public void MOCKCanGetAllFeaturedVehicles()
        {
            var manager = VehicleManagerFactory.Create();

            var response = manager.GetAllFeatured();

            Assert.AreEqual(true, response.Success);
        }


        [TestCase("00000000000000001", true)]
        [TestCase("0000000000000000a", false)]
        [TestCase("0000000000000000", false)]
        public void MOCKCanGetVehicleById(string vin, bool expected)
        {
            var manager = VehicleManagerFactory.Create();

            var response = manager.GetVehicle(vin);

            Assert.AreEqual(expected, response.Success);
        }

        [TestCase("00000000000000001", true)]
        [TestCase("0000000000000000a", false)]
        [TestCase("0000000000000000", false)]
        public void MOCKCanDeleteVehicleById(string vin, bool expected)
        {
            var manager = VehicleManagerFactory.Create();

            var response = manager.Delete(vin);

            Assert.AreEqual(expected, response.Success);
        }


        [TestCase("99999999999999999", true, 2018, 1, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "", false)]
        [TestCase("99999999999999999", true, 2018, 1, 1, 1, 1, 1, 2, 100, 25000, 30000, "", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", true, 2018, 1, 1, 1, 1, 1, 2, 100, 25000, 3000, "Test", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", false, 2018, 1, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", true, 2018, 1, 1, 1, 1, 1, 2, 10000, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", true, 2018, 1, 1, 1, 1, 1, 0, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", true, 2018, 1, 1, 1, 1, 0, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", true, 2018, 1, 1, 1, 0, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", true, 2018, 1, 1, 0, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", true, 2018, 1, 3, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", true, 2018, 9, 3, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", true, 2018, 0, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", true, 1999, 1, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("9999999999999999", true, 2018, 1, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("99999999999999999", true, 2018, 1, 1, 1, 1, 1, 2, 100, 29000, 30000, "Test", true, false, "test.jpg", true)]
        public void MOCKCanAddVehicle(string vin, bool condition, int year, int modleId, int makeId, BodyStyle bodyStyle, int colorId, int interiorId, Transmission transmission, int mileage, decimal salePrice, decimal msrp, string description, bool featured, bool sold, string imageFileName, bool expected)
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
                    ModelId = modleId,
                    Make = new Make
                    {
                        MakeId = makeId
                    }
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

            var manager = VehicleManagerFactory.Create();
            var response = manager.Add(vehicle);

            Assert.AreEqual(expected, response.Success);
        }



        [TestCase("00000000000000001", true, 2018, 1, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "", true)]
        [TestCase("00000000000000001", true, 2018, 1, 1, 1, 1, 1, 2, 100, 25000, 30000, "", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", true, 2018, 1, 1, 1, 1, 1, 2, 100, 25000, 3000, "Test", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", false, 2018, 1, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", true, 2018, 1, 1, 1, 1, 1, 2, 10000, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", true, 2018, 1, 1, 1, 1, 1, 0, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", true, 2018, 1, 1, 1, 1, 0, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", true, 2018, 1, 1, 1, 0, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", true, 2018, 1, 1, 0, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", true, 2018, 1, 3, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", true, 2018, 9, 3, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", true, 2018, 0, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", true, 1999, 1, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("0000000000000000", true, 2018, 1, 1, 1, 1, 1, 2, 100, 25000, 30000, "Test", true, false, "test.jpg", false)]
        [TestCase("00000000000000001", true, 2018, 1, 1, 1, 1, 1, 2, 100, 29000, 30000, "Test", true, false, "test.jpg", true)]
        public void MOCKCanEditVehicle(string vin, bool condition, int year, int modleId, int makeId, BodyStyle bodyStyle, int colorId, int interiorId, Transmission transmission, int mileage, decimal salePrice, decimal msrp, string description, bool featured, bool sold, string imageFileName, bool expected)
        {

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
                    ModelId = modleId,
                    Make = new Make
                    {
                        MakeId = makeId
                    }
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

            var manager = VehicleManagerFactory.Create();

            var response = manager.Edit(editVehicle);

            Assert.AreEqual(expected, response.Success);
        }
    }
}
