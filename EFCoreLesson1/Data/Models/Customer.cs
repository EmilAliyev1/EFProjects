using System.ComponentModel.DataAnnotations;
namespace EFCoreLesson1.Data.Models;

public class Customer
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    
    public string Name { get; set; }
    
    public List<Sale> Sales { get; set; } = new();
}