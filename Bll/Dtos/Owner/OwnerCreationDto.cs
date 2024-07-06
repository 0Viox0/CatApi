namespace Bll.Dtos.Owner;

public record OwnerCreationDto(
    string Name,
    DateOnly DateOfBirth,
    string Email,
    string Password);