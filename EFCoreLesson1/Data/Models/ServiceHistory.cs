using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreLesson1.Data.Models;

public class ServiceHistory
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public DateTime ServiceDate { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
}