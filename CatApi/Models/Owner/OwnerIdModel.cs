using CatApi.Models.Cat;

namespace CatApi.Models.Owner;

public record OwnerIdModel(
    int Id,
    string Name,
    DateOnly DateOfBirth,
    string Email,
    IList<CatModel> Cats);
