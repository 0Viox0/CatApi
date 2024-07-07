using Bll.Dtos.Owner;

namespace Bll.Services.User;

public interface IOwnerService
{
    public IList<OwnerDto> GetAllOwners();
    public OwnerIdDto GetOwnerById(int id);
    public OwnerIdDto CreateOwner(OwnerCreationDto ownerCreationDto);
    public OwnerIdDto DeleteOwnerById(int id);
}