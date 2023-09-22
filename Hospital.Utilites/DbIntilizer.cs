using Hospital.Models;
using Hospital.Repositonries;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Utilites
{
    public class DbIntilizer : IDbIntiilizer
    {
        private UserManager<IdentityUser> UserManager;
        private RoleManager<IdentityRole> roleManager;
        private AppDbContext context;

        public DbIntilizer(UserManager<IdentityUser> _userManager,
            RoleManager<IdentityRole> _roleManager, AppDbContext _context)
        {
            UserManager = _userManager;
            roleManager = _roleManager;
            context = _context;
        }

        public void Intiilizer()
        {
            try
            {
                if (context.Database.GetPendingMigrations().Count() > 0)
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception ex) { throw; }
            if (!roleManager.RoleExistsAsync(SiteRoles.Site_Admin).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new IdentityRole(SiteRoles.Site_Admin)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(SiteRoles.Site_Patiant)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(SiteRoles.Site_Doctor)).GetAwaiter().GetResult();
                UserManager.CreateAsync(new ApplecationUser
                {
                    UserName = "Zonkol",
                    Email = "Zonkol.com"
                }, "Mo@123456").GetAwaiter().GetResult();
                var appuser = context.applecationUsers.FirstOrDefault(x => x.Email == "Zonkol.com");

                if (appuser != null)
                {
                    UserManager.AddToRoleAsync(appuser,SiteRoles.Site_Admin).GetAwaiter().GetResult();
                }
            }
        }
    }
}
