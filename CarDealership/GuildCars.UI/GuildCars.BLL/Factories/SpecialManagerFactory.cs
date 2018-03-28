using GuildCars.BLL.Managers;
using GuildCars.Data;
using GuildCars.Data.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL.Factories
{
    public class SpecialManagerFactory
    {
        public static SpecialManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new SpecialManager(new SpecialRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
