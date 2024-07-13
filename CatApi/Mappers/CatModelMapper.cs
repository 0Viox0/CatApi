using Bll.CustomExceptions;
using Bll.Dtos.Cat;
using CatApi.Models.Cat;
using CatApi.Models.Owner;
using Dal.Enums;

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

    public CatIdModel ToCatIdModel(CatIdDto catIdDto)
    {
        return new CatIdModel(
            catIdDto.Id,
            catIdDto.Name,
            catIdDto.DateOfBirth,
            catIdDto.Breed,
            catIdDto.CatColor,
            catIdDto.OwnerDto is not null ? new OwnerModel(
                catIdDto.OwnerDto.Id,
                catIdDto.OwnerDto.Name,
                catIdDto.OwnerDto.DateOfBirth,
                catIdDto.OwnerDto.Name) : null,
            catIdDto.Friends.Select(ToCatModel).ToList());
    }

    public CatCreationDto ToCatCreationDto(CatCreationModel catCreationModel)
    {
        var catColorToCheck =
            char.ToUpper(catCreationModel.Color[0]) + catCreationModel.Color[1..].ToLower();
        
        if (!Enum.TryParse(catColorToCheck, out CatColor catColor))
        {
            throw new InvalidCatColorException($"cat color {catCreationModel.Color} is invalid");
        }
            
        return new CatCreationDto(
            catCreationModel.Name,
            catCreationModel.DateOfBirth,
            catCreationModel.Breed,
            catColor);
    }
}