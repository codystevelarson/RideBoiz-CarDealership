using GuildCars.BLL.Managers;
using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL.Factories
{
    public class CarModelManagerFactory
    {
        public static CarModelManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new CarModelManager(new CarModelRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
