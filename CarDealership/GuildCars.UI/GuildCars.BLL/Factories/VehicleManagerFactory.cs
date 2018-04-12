using GuildCars.BLL.Managers;
using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.TestRepos;
using System;

namespace GuildCars.BLL.Factories
{
    public class VehicleManagerFactory
    {
        public static VehicleManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new VehicleManager(new VehicleRepositoryTEST());
                case "Prod":
                    return new VehicleManager(new VehicleRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
