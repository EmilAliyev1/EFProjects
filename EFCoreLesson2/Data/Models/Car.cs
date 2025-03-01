using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreLesson2.Data.Models;

public class Car
{
    public int Id { get; set; }
    
    public string Make { get; set; }
    
    public string Model { get; set; }
    
    public string Color { get; set; } = "Black";
    
    public int Year { get; set; }
}