using KindergartenSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KindergartenSystem.Data
{
    public class KindergartenDbContext : IdentityDbContext<ApplicationUser>
    {
        public KindergartenDbContext(DbContextOptions<KindergartenDbContext> options)
            : base(options)
        {
            if (!Database.IsRelational())
            {
                Database.EnsureCreated();
            }
        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(KindergartenDbContext)) ??
                Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);
            base.OnModelCreating(builder);
        }
        public DbSet<Kindergarten> Kindergartens { get; set; } = null!;
        public DbSet<AgeGroup> AgeGroups { get; set; } = null!;
        public DbSet<ClassGroup> ClassGroups { get; set; } = null!;
        public DbSet<Child> Children { get; set; } = null!;
        public DbSet<Parent> Parents { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Image>? Image { get; set; } 
    }
}
