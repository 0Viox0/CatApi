using Bll.Dtos.Owner;
using CatApi.Models.Owner;

namespace CatApi.Mappers;

public class OwnerModelMapper(CatModelMapper catModelMapper)
{
    public OwnerModel ToOwnerModel(OwnerDto ownerDto)
    {
        return new OwnerModel(
            ownerDto.Id,
            ownerDto.Name,
            ownerDto.DateOfBirth,
            ownerDto.Email);
    }

    public OwnerIdModel ToOwnerIdModel(OwnerIdDto ownerIdDto)
    {
        return new OwnerIdModel(
            ownerIdDto.Id,
            ownerIdDto.Name,
            ownerIdDto.DateOfBirth,
            ownerIdDto.Email,
            ownerIdDto.Cats.Select(catModelMapper.ToCatModel).ToList());
    }
    public OwnerCreationDto ToOwnerCreationDto(OwnerCreationModel ownerCreationModel)
    {
        return new OwnerCreationDto(
            ownerCreationModel.Name,
            ownerCreationModel.DateOfBirth,
            ownerCreationModel.Email,
            ownerCreationModel.Password);
    }
}