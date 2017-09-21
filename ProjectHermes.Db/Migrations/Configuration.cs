namespace ProjectHermes.Db.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProjectHermes.Common;
    using ProjectHermes.Db.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            #region Seed Roles
            var initiator = new IdentityRole { Name = UserType.Initiator.ToString() };
            var supervisor = new IdentityRole { Name = UserType.Supervisor.ToString() };
            var CBYD = new IdentityRole { Name = UserType.CBYD.ToString() };
            var PURA = new IdentityRole { Name = UserType.PURA.ToString() };


            context.Roles.AddOrUpdate(
                r => r.Name,
                initiator,
                supervisor,
                CBYD,
                PURA
                );
            context.SaveChanges();
            #endregion

            #region Seed Users

            var userManager = new UserManager<User>(new UserStore<User>(context));
            userManager.UserValidator = new UserValidator<User>(userManager) { AllowOnlyAlphanumericUserNames = false };
            const string password = "P@ssw0rd";

            var initiatorUser = userManager.FindByEmail("initiator@demo.com");
            if (initiatorUser == null)
            {
                initiatorUser = new User
                {
                    FirstName = "Initiator",
                    LastName = "Demo",
                    UserName = "initiator@demo.com",
                    Email = "initiator@demo.com",
                    IsActive = true,
                    EmailConfirmed = true
                };

                var result = userManager.Create(initiatorUser, password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(initiatorUser.Id, UserType.Initiator.ToString());
                }
            }

            context.SaveChanges();
            #endregion
        }
    }
}
