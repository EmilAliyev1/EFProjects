using EFCoreLesson3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreLesson3.Data.Contexts;

public class ShowroomContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Dealer> Dealers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CarOrder> CarOrders { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
            .GetConnectionString("Default");
        
        optionsBuilder.UseSqlServer(connectionString);
    }
}