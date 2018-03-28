namespace GuildCars.UI.Migrations
{
    using GuildCars.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCars.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCars.UI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleMgr.RoleExists("Admin"))
            {
                roleMgr.Create(new IdentityRole() { Name = "Admin" });
            }



            if (!roleMgr.RoleExists("Sales"))
            {
                roleMgr.Create(new IdentityRole() { Name = "Sales" });
            }



            if (!roleMgr.RoleExists("Disabled"))
            {
                roleMgr.Create(new IdentityRole() { Name = "Disabled" });
            }


            if (!context.Users.Any(u => u.UserName == "Chuck@Testa.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "Chuck@Testa.com",
                    Email = "Chuck@Testa.com",
                    FirstName = "Chuck",
                    LastName = "Testa"
                };

                userMgr.Create(user, "123456");

                userMgr.AddToRole(user.Id, "Admin");
            }


            if (!context.Users.Any(u => u.UserName == "Cody@Testa.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "Cody@Testa.com",
                    Email = "Cody@Testa.com",
                    FirstName = "Cody",
                    LastName = "Testa"
                };

                userMgr.Create(user, "123456");

                userMgr.AddToRole(user.Id, "Admin");
            }



            if (!context.Users.Any(u => u.UserName == "GilGunderson@aol.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "GilGunderson@aol.com",
                    Email = "GilGunderson@aol.com",
                    FirstName = "Gil",
                    LastName = "Gunderson"
                };

                userMgr.Create(user, "123456");

                userMgr.AddToRole(user.Id, "Sales");
            }


            if (!context.Users.Any(u => u.UserName == "Hamburgler@mcdonalds.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "Hamburgler@mcdonalds.com",
                    Email = "Hamburgler@mcdonalds.com",
                    FirstName = "Ham",
                    LastName = "Burgler"
                };

                userMgr.Create(user, "123456");

                userMgr.AddToRole(user.Id, "Disabled");
            }
        }
    }
}
//Add NAMES OUTSIDE OF THE IFs AND THEN DELETE THEM