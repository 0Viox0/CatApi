using Bll.Dtos.Cat;
using Bll.Dtos.Owner;
using Dal.Models;

namespace Bll.Mappers;

public class CatDtoMapper
{
    public CatDto ToCatDto(Cat cat)
    {
        return new CatDto(
            cat.Id,
            cat.Name,
            cat.DateOfBirth,
            cat.Breed,
            cat.Color);
    }

    public CatIdDto ToCatIdDto(Cat cat)
    {
        return new CatIdDto(
            cat.Id,
            cat.Name,
            cat.DateOfBirth,
            cat.Breed,
            cat.Color,
            cat.Owner is not null ? new OwnerDto(cat.Owner.Id, cat.Owner.Name, cat.Owner.DateOfBirth, cat.Owner.Email) : null,
            cat.Friends.Select(ToCatDto).ToList());
    }
}