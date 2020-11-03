using ClothingStoreFranchise.NetCore.Customers.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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

        public DbSet<Product> Products { get; set; }
    }

    public class CustomersContextFactory : IDesignTimeDbContextFactory<CustomersContext>
    {
        public CustomersContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomersContext>()
                .UseSqlServer(@"data source = localhost\SQLEXPRESS; initial catalog = Customer;
                                Trusted_Connection = True; MultipleActiveResultSets = true")
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory());

            return new CustomersContext(optionsBuilder.Options);
        }
    }
}
