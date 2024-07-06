using Bll.Dtos.Cat;
using CatApi.Models.Cat;

namespace CatApi.Mappers;

public class CatModelMapper
{
    public CatModel ToCatModel(CatDto catDto)
    {
        return new CatModel(
            catDto.Id,
            catDto.Name,
            catDto.DateOfBirth,
            catDto.Breed,
            catDto.CatColor);
    }
}