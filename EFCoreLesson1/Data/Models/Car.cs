using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreLesson1.Data.Models;

public class Car
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Brand { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Model { get; set; }
    
    [Range(1886, 2100)]
    public int Year { get; set; }
    
    [Range(0, 1000000)]
    public decimal Price { get; set; }
    
    public List<Sale> Sales { get; set; } = new();
    public List<ServiceHistory> ServiceHistories { get; set; } = new();
}