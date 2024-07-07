using System.ComponentModel.DataAnnotations;

namespace CatApi.Models.Cat;

public class CatCreationModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    public DateOnly DateOfBirth { get; set; }
    
    [Required]
    public string Breed { get; set; }
    
    [Required]
    public string Color { get; set; }
}