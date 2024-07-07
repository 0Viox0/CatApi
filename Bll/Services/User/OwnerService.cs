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
            throw new UserNotFoundException($"user with id {id} was not found");
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
            throw new UserAlreadyExistsException($"the user with email {ownerCreationDto.Email} already exists");
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
            throw new UserNotFoundException($"user with id {id} was not found");
        }

        catApiDbContext.Remove(ownerToDelete);
        catApiDbContext.SaveChanges();

        return ownerDtoMapper.ToOwnerIdDto(ownerToDelete);
    }
}