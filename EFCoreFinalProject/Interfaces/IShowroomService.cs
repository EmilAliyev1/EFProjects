namespace EFCoreFinalProject.Interfaces;

public interface IShowroomService
{
    void RegisterUser(string firstName, string lastName, string phone);
    void RegisterCar(string make, string model, int year, int clientId);
    void RegisterOrder(int clientId, int carId, string status);
    void RegisterService(string name, decimal price);
    void AddingOrderToService(int orderId, int serviceId, int quantity);
    public void CountTotalOrdersPrice(int orderId);
    void ShowOrderHistory();
}