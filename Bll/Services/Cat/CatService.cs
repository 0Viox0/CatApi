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
            .Include(cat => cat.Owner)
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

    public CatIdDto DeleteCat(int id)
    {
        var cat = catApiDbContext.Cats
            .Include(cat => cat.Friends)
            .FirstOrDefault(cat => cat.Id == id);

        if (cat is null)
        {
            throw new CatNotFoundException($"the cat with id {id} was not found");
        }

        catApiDbContext.Cats.Remove(cat);

        return catDtoMapper.ToCatIdDto(cat);
    }

    public CatIdDto UpdateCatWithId(int id, CatCreationDto catUpdateDto)
    {
        var cat = catApiDbContext.Cats
            .Include(cat => cat.Owner)
            .Include(cat => cat.Friends)
            .FirstOrDefault(cat => cat.Id == id);

        if (cat is null)
        {
            throw new CatNotFoundException($"the cat with id {id} was not found");
        }

        cat.Name = catUpdateDto.Name;
        cat.DateOfBirth = catUpdateDto.DateOfBirth;
        cat.Color = catUpdateDto.Color;
        cat.Breed = catUpdateDto.Breed;

        catApiDbContext.SaveChanges();

        return catDtoMapper.ToCatIdDto(cat);
    }

    public CatIdDto BefriendCats(int firstCatId, int secondCatId)
    {
        if (firstCatId == secondCatId)
        {
            throw new FriendsWithItselfException("cat cannot be friends with itself");
        }
        
        var firstCat = catApiDbContext.Cats
            .Include(cat => cat.Owner)
            .Include(cat => cat.Friends)
            .FirstOrDefault(cat => cat.Id == firstCatId);

        var secondCat = catApiDbContext.Cats
            .Include(cat => cat.Owner)
            .Include(cat => cat.Friends)
            .FirstOrDefault(cat => cat.Id == secondCatId);

        CheckCatsAndTrowIfNeeded(firstCat, secondCat, firstCatId, secondCatId);

        firstCat!.Friends.Add(secondCat!);
        secondCat!.Friends.Add(firstCat);

        catApiDbContext.SaveChanges();

        return catDtoMapper.ToCatIdDto(firstCat);
    }

    public CatIdDto UnfriendCats(int firstCatId, int secondCatId)
    {
        var firstCat = catApiDbContext.Cats
            .Include(cat => cat.Owner)
            .Include(cat => cat.Friends)
            .FirstOrDefault(cat => cat.Id == firstCatId);

        var secondCat = catApiDbContext.Cats
            .Include(cat => cat.Owner)
            .Include(cat => cat.Friends)
            .FirstOrDefault(cat => cat.Id == secondCatId);

        CheckCatsAndTrowIfNeeded(firstCat, secondCat, firstCatId, secondCatId);

        firstCat!.Friends.Remove(secondCat!);
        secondCat!.Friends.Remove(firstCat);

        catApiDbContext.SaveChanges();

        return catDtoMapper.ToCatIdDto(firstCat);
    }

    private void CheckCatsAndTrowIfNeeded(
        Dal.Models.Cat? firstCat, Dal.Models.Cat? secondCat,
        int firstCatId, int secondCatId)
    {
        if (firstCat is null)
        {
            throw new CatNotFoundException($"first cat with id {firstCatId} was not found");
        }

        if (secondCat is null)
        {
            throw new CatNotFoundException($"second cat with id {secondCatId} was not found");
        }
    }
}
