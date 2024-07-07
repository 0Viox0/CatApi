using Bll.Dtos.Cat;

namespace Bll.Services.Cat;

public interface ICatService
{
    public List<CatDto> GetAllCats();
    public CatIdDto GetCatById(int id);
    CatIdDto CreateCat(CatCreationDto catCreationDto);
}