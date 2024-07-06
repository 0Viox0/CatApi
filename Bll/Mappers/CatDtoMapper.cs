using Bll.Dtos.Cat;
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
}