using Bll.CustomExceptions;
using Bll.Dtos.Cat;
using Bll.Mappers;
using Dal;
using Microsoft.EntityFrameworkCore;

namespace Bll.Services.Cat;

public class CatService(
    CatApiDbContext catApiDbContext,
    CatDtoMapper catDtoMapper) : ICatService
{
    public List<CatDto> GetAllCats()
    {
        return catApiDbContext.Cats.Select(catDtoMapper.ToCatDto).ToList();
    }

    public CatIdDto GetCatById(int id)
    {
        var cat = catApiDbContext.Cats
            .Include(c => c.Friends)
            .FirstOrDefault(c => c.Id == id);

        if (cat is null)
        {
            throw new CatNotFoundException($"the cat with id {id} was not found");
        }

        return catDtoMapper.ToCatIdDto(cat);
    }

    public CatIdDto CreateCat(CatCreationDto catCreationDto)
    {
        var cat = new Dal.Models.Cat
        {
            Name = catCreationDto.Name,
            DateOfBirth = catCreationDto.DateOfBirth,
            Breed = catCreationDto.Breed,
            Color = catCreationDto.Color,
        };

        cat.Friends = new List<Dal.Models.Cat>();

        catApiDbContext.Cats.Add(cat);
        catApiDbContext.SaveChanges();

        return catDtoMapper.ToCatIdDto(cat);
    }
}