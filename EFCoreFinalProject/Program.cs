using EFCoreFinalProject.CUI;
using EFCoreFinalProject.Data.Contexts;
using EFCoreFinalProject.Data.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        ShowroomServiceAppUi showroomServiceAppUi = new ShowroomServiceAppUi();
        showroomServiceAppUi.DisplayMenu();
        /*
        using var db = new ShowroomContext();
        db.Database.EnsureCreated();

        // Регистрация клиента
        var client = new Client { FirstName = "Иван", LastName = "Иванов", Phone = "+123456789" };
        db.Clients.Add(client);
        db.SaveChanges();

        // Добавление автомобиля клиента
        var car = new Car { Make = "Toyota", Model = "Camry", Year = 2020, ClientId = client.Id };
        db.Cars.Add(car);
        db.SaveChanges();

        // Создание заказа
        var order = new Order { ClientId = client.Id, CarId = car.Id, Date = DateTime.Now, Status = "Новый" };
        db.Orders.Add(order);
        db.SaveChanges();

        // Добавление услуги
        var service = new Service { Name = "Замена масла", Price = 3000 };
        db.Services.Add(service);
        db.SaveChanges();

        // Добавление услуги в заказ
        var orderService = new OrderService { OrderId = order.Id, ServiceId = service.Id, Quantity = 1, TotalPrice = service.Price };
        db.OrderServices.Add(orderService);
        db.SaveChanges();

        // Подсчет общей стоимости заказа
        decimal totalPrice = db.OrderServices.Where(os => os.OrderId == order.Id).Sum(os => os.TotalPrice);
        Console.WriteLine($"Общая стоимость заказа: {totalPrice}");

        // История заказов клиента
        var orderHistory = db.Orders.Where(o => o.ClientId == client.Id).Include(o => o.OrderServices).ThenInclude(os => os.Service).ToList();
        Console.WriteLine("История заказов:");
        foreach (var ord in orderHistory)
        {
            Console.WriteLine($"Заказ {ord.Id}, Дата: {ord.Date}, Статус: {ord.Status}");
            foreach (var os in ord.OrderServices)
            {
                Console.WriteLine($" - {os.Service.Name}, {os.Quantity} шт, {os.TotalPrice} руб.");
            }
        }
        */
    }
}