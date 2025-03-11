namespace EFCoreLesson3.Data.Models;
using System.ComponentModel.DataAnnotations;

public class Car
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Make { get; set; }
    
    [Required]
    public string Model { get; set; }
    
    [Range(1900, 2100)]
    public int Year { get; set; }
    
    public int DealerId { get; set; }
    public Dealer Dealer { get; set; }
    
    public bool IsDeleted { get; set; }
    public List<CarOrder> CarOrders { get; set; } = new();
}