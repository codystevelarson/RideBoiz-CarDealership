using GuildCars.BLL.Managers;
using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.TestRepos;
using System;

namespace GuildCars.BLL.Factories
{
    public class CarModelManagerFactory
    {
        public static CarModelManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new CarModelManager(new CarModelRepositoryTEST());
                case "Prod":
                    return new CarModelManager(new CarModelRepositoryADO()); 
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
