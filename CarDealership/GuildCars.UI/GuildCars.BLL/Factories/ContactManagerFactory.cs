using GuildCars.BLL.Managers;
using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.TestRepos;
using System;

namespace GuildCars.BLL.Factories
{
    public class ContactManagerFactory
    {
        public static ContactManager Create()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new ContactManager(new ContactRepositoryTEST());
                case "Prod":
                    return new ContactManager(new ContactRepositoryADO());
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
