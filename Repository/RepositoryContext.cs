using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
      
        public RepositoryContext(DbContextOptions options) : base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguraion());
        }

        DbSet<Company>? companies { get; set; }
        DbSet<Employee>? employees { get; set; }


    }
}