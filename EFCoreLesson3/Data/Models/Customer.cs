namespace EFCoreLesson3.Data.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CarOrder> CarOrders { get; set; } = new();
}