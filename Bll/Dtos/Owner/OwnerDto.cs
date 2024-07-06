namespace Bll.Dtos.Owner;

public record OwnerDto(
    int Id,
    string Name,
    DateOnly DateOfBirth,
    string Email);
