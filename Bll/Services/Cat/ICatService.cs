using Bll.Dtos.Cat;

namespace Bll.Services.Cat;

public interface ICatService
{
    public List<CatDto> GetAllCats();
    public CatIdDto GetCatById(int id);
    CatIdDto CreateCat(CatCreationDto catCreationDto);
    public CatIdDto DeleteCat(int id);
    public CatIdDto UpdateCatWithId(int id, CatCreationDto catCreationDto);

    public CatIdDto BefriendCats(int firstCatId, int secondCatId);
    public CatIdDto UnfriendCats(int firstCatId, int secondCatId);
}
