namespace EFCoreFinalProject.Data.Models;

public class Car
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}