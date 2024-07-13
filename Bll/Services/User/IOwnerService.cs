using Bll.Dtos.Owner;

namespace Bll.Services.User;

public interface IOwnerService
{
    public IList<OwnerDto> GetAllOwners();
    public OwnerIdDto GetOwnerById(int id);
    public OwnerIdDto CreateOwner(OwnerCreationDto ownerCreationDto);
    public OwnerIdDto DeleteOwnerById(int id);
    public OwnerIdDto UpdateOwnerWithId(int id, OwnerCreationDto ownerUpdateDto);
    public OwnerIdDto AssignCatToOwner(int ownerId, int catId);
    public OwnerIdDto DisownCatFromOwner(int ownerId, int catId);
}