using GuildCars.BLL.Managers;
using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.TestRepos;
using System;

namespace GuildCars.BLL.Factories
{
    public class SpecialManagerFactory
    {
        public static SpecialManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new SpecialManager(new SpecialRepositoryTEST());
                case "Prod":
                    return new SpecialManager(new SpecialRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
