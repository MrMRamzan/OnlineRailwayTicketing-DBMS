//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using OnlineRailwayReservationSystem.Models;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

[assembly: OwinStartupAttribute(typeof(OnlineRailwayReservationSystem.Startup))]
namespace OnlineRailwayReservationSystem
{
    public partial class Startup
    {
        //public System.Data.Entity.DbSet<userroles.Models.ApplicationUser> IdentityUsers { get; set; }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));



            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("A"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "A";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "ADMIN@GOOGLE.COM";
                user.Email = "ADMIN@GOOGLE.COM";

                string userPWD = "G00gle.";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "A");

                }
            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("U"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "U";
                roleManager.Create(role);
            }
        }
    }
}
