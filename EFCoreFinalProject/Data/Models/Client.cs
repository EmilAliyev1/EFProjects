namespace EFCoreFinalProject.Data.Models;

public class Client
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public ICollection<Car> Cars { get; set; } = new List<Car>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}