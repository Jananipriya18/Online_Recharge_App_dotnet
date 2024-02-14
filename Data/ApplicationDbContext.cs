using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using Microsoft.AspNetCore.Identity;

namespace dotnetapp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Addon> Addons { get; set; }
        public DbSet<Recharge> Recharges { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
