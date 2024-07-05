using Bll.Dtos.Owner;
using Dal.Models;

namespace Bll.Mappers;

public class OwnerDtoMapper
{
    public OwnerDto ToOwnerDto(Owner owner)
    {
        return new OwnerDto(
            owner.Id,
            owner.Name,
            owner.DateOfBirth);
    }
}