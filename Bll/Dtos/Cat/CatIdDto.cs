using Bll.Dtos.Owner;
using Dal.Enums;

namespace Bll.Dtos.Cat;

public record CatIdDto(
    int Id,
    string Name,
    DateOnly DateOfBirth,
    string Breed,
    CatColor CatColor,
    OwnerDto? OwnerDto,
    List<CatDto> Friends);