

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

            public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }

    public class ApplicationUser
    {
        public string? Appuser { get; set; }
        public string? Email { get; set; }
    }
}