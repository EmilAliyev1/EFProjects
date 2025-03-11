using System.ComponentModel.DataAnnotations;

namespace EFCoreLesson3.Data.Models;

public class CarOrder
{
    [Key]
    public int Id { get; set; }
    
    public int CarId { get; set; }
    public Car Car { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}