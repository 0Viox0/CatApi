using Dal.Enums;

namespace Bll.Dtos.Cat;

public record CatCreationDto(
    string Name,
    DateOnly DateOfBirth,
    string Breed,
    CatColor Color);