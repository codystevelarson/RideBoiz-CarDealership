using GuildCars.BLL.Managers;
using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.TestRepos;
using System;

namespace GuildCars.BLL.Factories
{
    public class StateManagerFactory
    {
        public static StateManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new StateManager(new StateRepositoryTEST());
                case "Prod":
                    return new StateManager(new StateRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
