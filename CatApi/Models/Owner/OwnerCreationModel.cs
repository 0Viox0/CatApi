using System.ComponentModel.DataAnnotations;

namespace CatApi.Models.Owner;

public class OwnerCreationModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    public DateOnly DateOfBirth { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required] 
    public string Password { get; set; }
}