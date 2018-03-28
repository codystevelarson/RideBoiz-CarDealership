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
    public class MakeManagerFactory
    {
        public static MakeManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new MakeManager(new MakeRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
