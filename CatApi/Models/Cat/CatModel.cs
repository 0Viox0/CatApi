using Dal.Enums;

namespace CatApi.Models.Cat;

public record CatModel(
    int Id,
    string Name,
    DateOnly DateOfBirth,
    string Breed,
    CatColor CatColor);