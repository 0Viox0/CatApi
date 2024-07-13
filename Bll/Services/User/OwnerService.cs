using Bll.CustomExceptions;
using Bll.Dtos.Owner;
using Bll.Mappers;
using Dal;
using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Bll.Services.User;

public class OwnerService(
    CatApiDbContext catApiDbContext,
    OwnerDtoMapper ownerDtoMapper) : IOwnerService
{
    public IList<OwnerDto> GetAllOwners()
    {
        return catApiDbContext.Owners.
            Select(ownerDtoMapper.ToOwnerDto)
            .ToList();
    }

    public OwnerIdDto GetOwnerById(int id)
    {
        var owner = catApiDbContext.Owners
            .Include(owner => owner.Cats)
            .FirstOrDefault(owner => owner.Id == id);
        

        if (owner is null)
        {
            throw new OwnerNotFoundException($"owner with id {id} was not found");
        }

        return ownerDtoMapper.ToOwnerIdDto(owner);
    }

    public OwnerIdDto CreateOwner(OwnerCreationDto ownerCreationDto)
    {
        var owner = catApiDbContext.Owners
            .AsNoTracking()
            .FirstOrDefault(o => o.Email.Equals(ownerCreationDto.Email));

        if (owner is not null)
        {
            throw new OwnerAlreadyExistsException($"the owner with email {ownerCreationDto.Email} already exists");
        }

        var newOwner = new Owner
        {
            Name = ownerCreationDto.Name,
            DateOfBirth = ownerCreationDto.DateOfBirth,
            Email = ownerCreationDto.Email,
            Password = ownerCreationDto.Password
        };

        catApiDbContext.Owners.Add(newOwner);
        catApiDbContext.SaveChanges();

        newOwner.Cats = new List<Dal.Models.Cat>();

        return ownerDtoMapper.ToOwnerIdDto(newOwner);
    }

    public OwnerIdDto DeleteOwnerById(int id)
    {
        var ownerToDelete = catApiDbContext.Owners
            .Include(o => o.Cats)
            .FirstOrDefault(owner => owner.Id == id);

        if (ownerToDelete is null)
        {
            throw new OwnerNotFoundException($"owner with id {id} was not found");
        }

        catApiDbContext.Remove(ownerToDelete);
        catApiDbContext.SaveChanges();

        return ownerDtoMapper.ToOwnerIdDto(ownerToDelete);
    }

    public OwnerIdDto UpdateOwnerWithId(int id, OwnerCreationDto ownerUpdateDto)
    {
        var owner = catApiDbContext.Owners
            .Include(owner => owner.Cats)
            .FirstOrDefault(owner => owner.Id == id);

        if (owner is null)
        {
            throw new OwnerNotFoundException($"owner with id {id} was not found");
        }

        owner.Name = ownerUpdateDto.Name;
        owner.DateOfBirth = ownerUpdateDto.DateOfBirth;
        owner.Email = ownerUpdateDto.Email;
        owner.Password = ownerUpdateDto.Password;

        catApiDbContext.SaveChanges();

        return ownerDtoMapper.ToOwnerIdDto(owner);
    }

    public OwnerIdDto AssignCatToOwner(int ownerId, int catId)
    {
        var owner = catApiDbContext.Owners
            .Include(owner => owner.Cats)
            .FirstOrDefault(owner => owner.Id == ownerId);

        var cat = catApiDbContext.Cats
            .Include(cat => cat.Owner)
            .FirstOrDefault(cat => cat.Id == catId);

        if (owner is null)
        {
            throw new OwnerNotFoundException($"owner with id {ownerId} was not found");
        }

        if (cat is null)
        {
            throw new CatNotFoundException($"the cat with id {catId} was not found");
        }

        if (cat.Owner is not null && cat.OwnerId != ownerId)
        {
            throw new CatAlreadyHasAnOwner($"you can't steal a cat from an existing owner with id {cat.OwnerId}");
        }
        
        owner.Cats.Add(cat);
        cat.OwnerId = owner.Id;
        cat.Owner = owner;

        catApiDbContext.SaveChanges();

        return ownerDtoMapper.ToOwnerIdDto(owner);
    }

    public OwnerIdDto DisownCatFromOwner(int ownerId, int catId)
    {
        var owner = catApiDbContext.Owners
            .Include(owner => owner.Cats)
            .FirstOrDefault(owner => owner.Id == ownerId);

        var cat = catApiDbContext.Cats
            .Include(cat => cat.Owner)
            .FirstOrDefault(cat => cat.Id == catId);

        if (owner is null)
        {
            throw new OwnerNotFoundException($"owner with id {ownerId} was not found");
        }

        if (cat is null)
        {
            throw new CatNotFoundException($"the cat with id {catId} was not found");
        }

        owner.Cats.Remove(cat);
        cat.Owner = null;
        cat.OwnerId = null;

        catApiDbContext.SaveChanges();

        return ownerDtoMapper.ToOwnerIdDto(owner);
    }
}