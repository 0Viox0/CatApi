using Bll.Dtos.Owner;
using Bll.Mappers;
using Dal;
using Microsoft.EntityFrameworkCore;

namespace Bll.Services;

public class OwnerService(
    CatApiDbContext catApiDbContext,
    OwnerDtoMapper ownerDtoMapper)
{
    public IEnumerable<OwnerDto> GetAllOwners()
    {
        return catApiDbContext.Owners.AsNoTracking().AsEnumerable().Select(ownerDtoMapper.ToOwnerDto);
    }
}