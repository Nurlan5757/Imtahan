using Imtahan.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Imtahan.DAL
{
    public class FreshContext : IdentityDbContext<AppUser>
    {

        public FreshContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Chefs> chefs { get; set; }

        public DbSet<AppUser> appUsers { get; set; }
    }
}
        