using GuildCars.BLL.Managers;
using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.TestRepos;
using System;

namespace GuildCars.BLL.Factories
{
    public class MakeManagerFactory
    {
        public static MakeManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new MakeManager(new MakeRepositoryTEST());
                case "Prod":
                    return new MakeManager(new MakeRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
