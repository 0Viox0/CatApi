using Bll.Dtos.Owner;
using CatApi.Models.Owner;

namespace CatApi.Mappers;

public class OwnerModelMapper
{
    public OwnerModel ToOwnerModel(OwnerDto ownerDto)
    {
        return new OwnerModel(
            ownerDto.Id,
            ownerDto.Name,
            ownerDto.DateOfBirth);
    }
}