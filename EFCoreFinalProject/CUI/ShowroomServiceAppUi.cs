using EFCoreFinalProject.Implementations;

namespace EFCoreFinalProject.CUI;

public class ShowroomServiceAppUi
{
    private readonly Menu? _menu = new Menu();
    private readonly ShowroomService? _showroomService = new ShowroomService();
    private readonly GetValueService? _getValueService = new GetValueService();
    private bool running = true;

    private List<MenuChoice> _showroomMenuChoices = new()
    {
        new() { Id = 1, Description = "Регистрация новых клиентов" },
        new() { Id = 2, Description = "Добавление автомобилей клиентов" },
        new() { Id = 3, Description = "Создание заказов на обслуживание" },
        new () { Id = 4, Description = "Создание услуги"},
        new() { Id = 5, Description = "Выбор услуг для заказа" },
        new() { Id = 6, Description = "Подсчет общей стоимости заказа" },
        new() { Id = 7, Description = "Вывод истории заказов клиентов" },
        new() { Id = 8, Description = "Exit the App" },
    };

    public void DisplayMenu()
    {
        while (running)
        {
            try
            {
                MenuChoice choice = _menu.MenuOperate(_showroomMenuChoices);
                switch (choice.Id)
                {
                    case 1:
                        Console.Write("Enter the client's first name: ");
                        string firstName = _getValueService.GetStringInputValue();
                        
                        Console.Write("Enter the client's last name: ");
                        string lastName = _getValueService.GetStringInputValue();
                        
                        Console.Write("Enter the client's phone number: ");
                        string phoneNumber = _getValueService.GetStringInputValue();
                        
                        _showroomService.RegisterUser(firstName, lastName, phoneNumber);
                        break;
                    case 2:
                        Console.Write("Enter the car's brand: ");
                        string make = _getValueService.GetStringInputValue();
                        
                        Console.Write("Enter the car's model: ");
                        string model = _getValueService.GetStringInputValue();
                        
                        Console.Write("Enter the car's year: ");
                        int year = _getValueService.GetIntInputValue();
                        
                        Console.Write("Enter the client's id: ");
                        int clientId = _getValueService.GetIntInputValue();
                        
                        _showroomService.RegisterCar(make, model, year, clientId);
                        
                        break;
                    case 3:
                        Console.Write("Enter the client's id: ");
                        int clientId2 = _getValueService.GetIntInputValue();
                        
                        Console.Write("Enter the car's id: ");
                        int carId = _getValueService.GetIntInputValue();
                        
                        Console.Write("Enter the status of the order: ");
                        string status = _getValueService.GetStringInputValue();
                        
                        _showroomService.RegisterOrder(clientId2, carId, status);
                        
                        break;
                    case 4:
                        Console.Write("Enter the name of the service: ");
                        string serviceName = _getValueService.GetStringInputValue();
                        
                        Console.Write("Enter the price of the service: ");
                        decimal servicePrice = _getValueService.GetDecimalInputValue();
                        
                        _showroomService.RegisterService(serviceName, servicePrice);

                        break;
                    case 5:
                        Console.Write("Enter the order's id: ");
                        int orderId = _getValueService.GetIntInputValue();
                        
                        Console.Write("Enter the service's id: ");
                        int serviceId = _getValueService.GetIntInputValue();
                        
                        Console.Write("Enter the quantity: ");
                        int quantity = _getValueService.GetIntInputValue();
                        
                        _showroomService.AddingOrderToService(orderId, serviceId, quantity);
                        
                        break;
                    case 6:
                        Console.Write("Enter the order's id: ");
                        int orderId2 = _getValueService.GetIntInputValue();
                        
                        _showroomService.CountTotalOrdersPrice(orderId2);
                        
                        break;
                    case 7:
                        _showroomService.ShowOrderHistory();
                        break;
                    case 8:
                        running = false;
                        Console.WriteLine("Goodbye");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}