using Dal.Enums;

namespace Bll.Dtos.Cat;

public record CatDto(
    int Id,
    string Name,
    DateOnly DateOfBirth,
    string Breed,
    CatColor CatColor);
