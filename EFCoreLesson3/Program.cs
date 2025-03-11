using EFCoreLesson3.Data.Contexts;
using EFCoreLesson3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLesson3;

class Program
{
    static void Main()
    {
        var context = new ShowroomContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        
        var dealer = new Dealer { Name = "Em4ik", Location = "FFF" };
        context.Dealers.Add(dealer);
        context.SaveChanges();

        var car = new Car { Make = "Toyota", Model = "Corolla", Year = 2022, DealerId = dealer.Id };
        context.Cars.Add(car);
        context.SaveChanges();
        
        var dealersWithCars = context.Dealers.Include(d => d.Cars).ToList();
        foreach (var d in dealersWithCars)
        {
            Console.WriteLine($"Dealer: {d.Name}, Cars: {string.Join(", ", d.Cars.Select(c => c.Model))}");
        }
    }
}