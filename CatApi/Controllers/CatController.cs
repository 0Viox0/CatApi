using Asp.Versioning;
using Bll.Services.Cat;
using CatApi.Mappers;
using CatApi.Models.Cat;
using Microsoft.AspNetCore.Mvc;

namespace CatApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/[controller]")]
public class CatController(
    ICatService catService,
    CatModelMapper catModelMapper) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllCats(string? color, string? breed)
    {
        return Ok(catService.GetAllCats(color, breed).Select(catModelMapper.ToCatModel).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetCatById(int id)
    {
        var cat = catService.GetCatById(id);

        return Ok(catModelMapper.ToCatIdModel(cat));
    }

    [HttpPost]
    public IActionResult CreateCat(CatCreationModel catCreationModel)
    {
        var catIdDto = catService.CreateCat(catModelMapper.ToCatCreationDto(catCreationModel));

        return Ok(catModelMapper.ToCatIdModel(catIdDto));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCat(int id)
    {
        var catIdDto = catService.DeleteCat(id);

        return Ok(catModelMapper.ToCatIdModel(catIdDto));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCat(int id, CatCreationModel catUpdateModel)
    {
        var catIdDto = catService.UpdateCatWithId(id, catModelMapper.ToCatCreationDto(catUpdateModel));

        return Ok(catModelMapper.ToCatIdModel(catIdDto));
    }

    [HttpPut("{id1}/friends-with/{id2}")]
    public IActionResult BefriendCats(int id1, int id2)
    {
        var firstCatIdDto = catService.BefriendCats(id1, id2);

        return Ok(catModelMapper.ToCatIdModel(firstCatIdDto));
    }

    [HttpDelete("{id1}/not-friends-with/{id2}")]
    public IActionResult DefriendCats(int id1, int id2)
    {
        var firstCatIdDto = catService.UnfriendCats(id1, id2);

        return Ok(catModelMapper.ToCatIdModel(firstCatIdDto));
    }
}