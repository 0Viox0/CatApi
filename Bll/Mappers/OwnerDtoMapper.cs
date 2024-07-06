using Bll.Dtos.Cat;
using Bll.Dtos.Owner;
using Dal.Models;

namespace Bll.Mappers;

public class OwnerDtoMapper(CatDtoMapper catDtoMapper)
{
    public OwnerDto ToOwnerDto(Owner owner)
    {
        return new OwnerDto(
            owner.Id,
            owner.Name,
            owner.DateOfBirth,
            owner.Email);
    }

    public OwnerIdDto ToOwnerIdDto(Owner owner)
    {
        return new OwnerIdDto(
            owner.Id,
            owner.Name,
            owner.DateOfBirth,
            owner.Email,
            owner.Cats.Select(catDtoMapper.ToCatDto).ToList());
    }
    
    
}