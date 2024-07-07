using System.ComponentModel.DataAnnotations;
using Dal.Enums;

namespace Dal.Models;

public class Cat
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Breed { get; set; }
    public CatColor Color { get; set; }
    public int? OwnerId { get; set; }
    
    public Owner? Owner { get; set; }
    public ICollection<Cat> Friends { get; set; }
}