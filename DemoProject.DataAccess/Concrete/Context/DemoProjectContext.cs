using DemoProject.DataAccess.Concrete.Mapping;
using DemoProject.Entities.Concrete;
using DemoProject.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoProject.DataAccess.Concrete.Context
{
    public class DemoProjectContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DemoProjectContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("db"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new AppRoleMap());
        }

        #region DbSet

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        #endregion
    }
}
