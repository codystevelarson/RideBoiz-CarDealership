using GuildCars.BLL.Managers;
using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.TestRepos;
using System;

namespace GuildCars.BLL.Factories
{
    public class SaleItemManagerFactory
    {
        public static SaleItemManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new SaleItemManager(new SaleItemRepositoryTEST());
                case "Prod":
                    return new SaleItemManager(new SaleItemRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
