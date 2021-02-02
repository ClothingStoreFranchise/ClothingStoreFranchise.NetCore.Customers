using ClothingStoreFranchise.NetCore.Customers.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ClothingStoreFranchise.NetCore.Customers
{
    public class CustomersContext : DbContext
    {
        public CustomersContext(DbContextOptions<CustomersContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CartProduct> CartProducts { get; set; }

        public DbSet<SizeStock> SizeStocks { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }

    public class CustomersContextFactory : IDesignTimeDbContextFactory<CustomersContext>
    {
        public CustomersContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = Program.GetConfiguration();

            var optionsBuilder = new DbContextOptionsBuilder<CustomersContext>()
                .UseSqlServer(@configuration["DatabaseConnection:DataSource"])
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory());

            return new CustomersContext(optionsBuilder.Options);
        }
    }
}
