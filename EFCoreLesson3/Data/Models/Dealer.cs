namespace EFCoreLesson3.Data.Models;

public class Dealer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public List<Car> Cars { get; set; } = new();
}