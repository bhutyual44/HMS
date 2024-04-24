using Hospital.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitals.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;
      

        public DbInitializer(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize(Hospital.Repositories.ApplicationUser appuser)
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }

            }
            catch(Exception)
            {
                throw;

            }
            if (!_roleManager.RoleExistsAsync(WebSiteRoles.WebSites_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSites_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSites_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSites_Doctor)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Hari",
                    Email= "Hari@xyz.com"

                }, "Hari@123").GetAwaiter().GetResult() ;

                var Appuser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "Hari@xyz.com");
                if (Appuser != null)
                {
                    var unused = _userManager.AddToRoleAsync(Appuser, WebSiteRoles.WebSites_Admin).GetAwaiter().GetResult();
                }
            }


        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }

   internal class ApplicationUser : IdentityUser
    {
    }
}
