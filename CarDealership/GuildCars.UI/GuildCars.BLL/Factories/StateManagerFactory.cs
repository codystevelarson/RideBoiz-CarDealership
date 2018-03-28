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
    public class StateManagerFactory
    {
        public static StateManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new StateManager(new StateRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
