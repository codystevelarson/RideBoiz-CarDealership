using GuildCars.BLL.Managers;
using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.TestRepos;
using System;

namespace GuildCars.BLL.Factories
{
    public class ColorManagerFactory
    {
        public static ColorManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new ColorManager(new ColorRepositoryTEST());
                case "Prod":
                    return new ColorManager(new ColorRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
