namespace EFCoreFinalProject.Data.Models;

public class Order
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
}