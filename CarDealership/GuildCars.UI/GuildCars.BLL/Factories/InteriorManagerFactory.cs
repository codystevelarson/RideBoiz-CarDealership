using GuildCars.BLL.Managers;
using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.TestRepos;
using System;

namespace GuildCars.BLL.Factories
{
    public class InteriorManagerFactory
    {
        public static InteriorManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new InteriorManager(new InteriorRepositoryTEST());
                case "Prod":
                    return new InteriorManager(new InteriorRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
