using EFCoreFinalProject.Data.Contexts;
using EFCoreFinalProject.Data.Models;
using EFCoreFinalProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFinalProject.Implementations;

public class ShowroomService : IShowroomService
{
    private readonly ShowroomContext _db = new ShowroomContext();

    public ShowroomService()
    {
        _db.Database.EnsureCreated();
    }

    public void RegisterUser(string firstName, string lastName, string phone)
    {
        var client = new Client { FirstName = firstName, LastName = lastName, Phone = phone };
        _db.Clients.Add(client);
        _db.SaveChanges();
    }

    public void RegisterCar(string make, string model, int year, int clientId)
    {
        var client = _db.Clients.Find(clientId);
        if (client != null)
        {
            var car = new Car { Make = make, Model = model, Year = year, ClientId = clientId };
            _db.Cars.Add(car);
        }
        else
        {
            throw new Exception("Client not found");
        }
        
        _db.SaveChanges();
    }

    public void RegisterOrder(int clientId, int carId, string status)
    {
        var car = _db.Cars.Find(carId);
        if (car != null)
        {
            var order = new Order { ClientId = clientId, CarId = carId, Date = DateTime.Now, Status = status };
            _db.Orders.Add(order);
        }
        else
        {
            throw new Exception("Car not found");
        }
        
        _db.SaveChanges();
    }

    public void RegisterService(string name, decimal price)
    {
        var service = new Service { Name = name, Price = price };
        _db.Services.Add(service);
        _db.SaveChanges();
    }

    public void AddingOrderToService(int orderId, int serviceId, int quantity)
    {
        var service = _db.Services.Find(serviceId);
        var order = _db.Orders.Find(orderId);
        if (service != null && order != null)
        {
            var orderService = new OrderService { OrderId = orderId, ServiceId = serviceId, Quantity = quantity, TotalPrice = service.Price };
            _db.OrderServices.Add(orderService);
        }
        else
        {
            throw new Exception("Service or Order not found");
        }

        _db.SaveChanges();
    }

    public void CountTotalOrdersPrice(int orderId)
    {
        var order = _db.Orders.Find(orderId);
        if (order != null)
        {
            decimal totalPrice = _db.OrderServices.Where(os => os.OrderId == orderId).Sum(os => os.TotalPrice);
            Console.WriteLine($"Total price of the order: {totalPrice}");
        }
        else
        {
            throw new Exception("Order not found");
        }
    }
    
    public void ShowOrderHistory()
    {
        var orders = _db.Orders.Include(o => o.Client).Include(o => o.Car).Include(o => o.OrderServices).ThenInclude(os => os.Service);
        
        foreach (var order in orders)
        {
            Console.WriteLine($"\nOrder #{order.Id} | Client: {order.Client.FirstName} {order.Client.LastName} | Car: {order.Car.Make} {order.Car.Model} | Date: {order.Date} | Status: {order.Status}");
            Console.WriteLine("Services:");
            foreach (var os in order.OrderServices)
            {
                Console.WriteLine($" - {os.Service.Name}: {os.Quantity} x {os.Service.Price} usd = {os.TotalPrice} usd");
            }
        }
    }
}