using System.ComponentModel.DataAnnotations;

namespace Dal.Models;

public class Owner
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public ICollection<Cat> Cats { get; set; }
}