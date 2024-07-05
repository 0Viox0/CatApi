using Bll.Dtos.Cat;

namespace Bll.Dtos.Owner;

public record OwnerIdDto(
    int Id,
    string Name,
    DateOnly DateOfBirth,
    List<CatDto> Cats);