using EFCoreLesson1.Data.Contexts;
using EFCoreLesson1.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// ya ne ponal HasData() eto skoree vsego fluent api, k tomu vremeni mi ese ne prosli ego poetomu i bez nego soydet

class Program
{
    static void Main()
    {
        using var context = new ShowroomContext();
        
        DisplayCars(context);
        
        FindCarsByCustomer(context, "Ivan Petrov");
        GetSalesByPeriod(context, DateTime.Now.AddMonths(-1), DateTime.Now);
        GetSalesCountByEmployees(context);
    }

    static void DisplayCars(ShowroomContext context)
    {
        Console.WriteLine("Available cars: ");
        foreach (var car in context.Cars.ToList())
        {
            Console.WriteLine($"{car.Brand} {car.Model}, {car.Year} - {car.Price} USD");
        }
    }
    
    static void FindCarsByCustomer(ShowroomContext context, string customerName)
    {
        var cars = context.Sales
            .Where(s => s.Customer.Name == customerName)
            .Select(s => s.Car)
            .ToList();

        Console.WriteLine($"Car is bought by: {customerName}:");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Brand} {car.Model}, {car.Year} - {car.Price} USD");
        }
    }
    
    static void GetSalesByPeriod(ShowroomContext context, DateTime startDate, DateTime endDate)
    {
        var sales = context.Sales
            .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
            .Include(sale => sale.Car)
            .Include(sale => sale.Customer)
            .ToList();

        Console.WriteLine($"Sales from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}:");
        foreach (var sale in sales)
        {
            Console.WriteLine($"{sale.Car.Brand} {sale.Car.Model} is sold {sale.Customer.Name} for {sale.Price} USD {sale.SaleDate.ToShortDateString()}");
        }
    }
    
    static void GetSalesCountByEmployees(ShowroomContext context)
    {
        var salesCount = context.Sales
            .GroupBy(s => s.Employee.Name)
            .Select(g => new { EmployeeName = g.Key, SalesCount = g.Count() })
            .ToList();

        Console.WriteLine("The amount of sales of every employee: ");
        foreach (var item in salesCount)
        {
            Console.WriteLine($"{item.EmployeeName}: {item.SalesCount} sales");
        }
    }
}

