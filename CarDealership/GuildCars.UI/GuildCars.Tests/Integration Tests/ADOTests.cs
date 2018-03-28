using GuildCars.Data.ADO;
using GuildCars.Models.Enums;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests.Integration_Tests
{
    [TestFixture]
    public class ADOTests
    {

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
            Assert.AreEqual("Challenger", vehicles[0].ModelName);
            Assert.AreEqual("Dodge", vehicles[0].MakeName);
            Assert.AreEqual(BodyStyle.Car, vehicles[0].BodyStyle);
            Assert.AreEqual("White", vehicles[0].ColorName);
            Assert.AreEqual("Leather", vehicles[0].InteriorName);
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
            Assert.AreEqual(BodyStyle.Car, vehicle.BodyStyle);
            Assert.AreEqual("White", vehicle.ColorName);
            Assert.AreEqual("Leather", vehicle.InteriorName);
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
            Assert.AreEqual("Focus", models[0].ModelName);
            Assert.AreEqual("Chuck@Testa.com", models[0].UserName);
            Assert.IsNotNull(models[0].DateAdded);
        }


        [TestCase("", false)]
        [TestCase("xxxxxxx", false)]
        [TestCase("Focus", true)]
        public void CanLoadModelByName(string modelName, bool expected)
        {
            bool actual = false;

            var repo = new CarModelRepositoryADO();

            CarModel model = repo.GetModel(modelName);

            if(model != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
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

        [TestCase("", false)]
        [TestCase("xxxx", false)]
        [TestCase("Ford", true)]
        public void CanLoadMakeByName(string makeName, bool expected)
        {
            bool actual = false;

            var repo = new MakeRepositoryADO();

            Make make = repo.GetMake(makeName);

            if(make != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);

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
    }
}
