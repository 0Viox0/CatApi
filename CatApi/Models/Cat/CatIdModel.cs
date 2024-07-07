using Bll.Dtos.Cat;
using Bll.Dtos.Owner;
using CatApi.Models.Owner;
using Dal.Enums;

namespace CatApi.Models.Cat;

public record CatIdModel(
    int Id,
    string Name,
    DateOnly DateOfBirth,
    string Breed,
    CatColor CatColor,
    OwnerModel? OwnerModel,
    List<CatModel> Friends);
