namespace EFCoreLesson1.Data.Models;

public class Sale
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    // public DateTime SaleDate { get; set; }
    public decimal Price { get; set; }
}