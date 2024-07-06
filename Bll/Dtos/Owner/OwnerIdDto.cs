using Bll.Dtos.Cat;

namespace Bll.Dtos.Owner;

public record OwnerIdDto(
    int Id,
    string Name,
    DateOnly DateOfBirth,
    string Email,
    IList<CatDto> Cats);