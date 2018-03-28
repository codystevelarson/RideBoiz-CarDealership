using GuildCars.BLL.Factories;
using GuildCars.BLL.Managers;
using GuildCars.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL.Tests
{
    [TestFixture]
    public class MangerTests
    {
        [Test]
        public void CanLoadAllVehicles()
        {
            var manager = VehicleManagerFactory.Create();

            var response = manager.GetAll();

            Assert.IsNotNull(response.Vehicles);
            Assert.AreEqual(true, response.Success);
        }


        [Test]
        public void CanLoadAllNewVehicles()
        {
            var manager = VehicleManagerFactory.Create();

            var response = manager.GetAllNew();

            Assert.IsNotNull(response.Vehicles);
            Assert.AreEqual(true, response.Vehicles.All(v => v.New == true));
            Assert.AreEqual(true, response.Success);
        }


        [Test]
        public void CanLoadAllUsedVehicles()
        {
            var manager = VehicleManagerFactory.Create();

            var response = manager.GetAllUsed();

            Assert.IsNotNull(response.Vehicles);
            Assert.AreEqual(true, response.Vehicles.All(v => v.New == false));
            Assert.AreEqual(true, response.Success);
        }


        [Test]
        public void CanLoadAllFeaturedVehicles()
        {
            var manager = VehicleManagerFactory.Create();

            var response = manager.GetAllFeatured();

            Assert.IsNotNull(response.Vehicles);
            Assert.AreEqual(true, response.Vehicles.All(v => v.Featured == true));
            Assert.AreEqual(true, response.Success);
        }


        [Test]
        public void CanLoadSpecials()
        {
            var manager = SpecialManagerFactory.Create();

            var response = manager.GetAll();

            Assert.IsNotNull(response.Specials);
            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(10, response.Specials.Count());
        }


        [Test]
        public void CanLoadMakes()
        {
            var manager = MakeManagerFactory.Create();

            var response = manager.GetAll();

            Assert.IsNotNull(response.Makes);
            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(10, response.Makes.Count());
        }


        [Test]
        public void CanLoadCarModels()
        {
            var manager = CarModelManagerFactory.Create();

            var response = manager.GetAll();

            Assert.IsNotNull(response.CarModels);
            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(30, response.CarModels.Count());
        }
    }
}
