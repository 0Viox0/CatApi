using Asp.Versioning;
using Bll.Services.Cat;
using CatApi.Mappers;
using CatApi.Models.Cat;
using CatApi.Models.Owner;
using Microsoft.AspNetCore.Mvc;

namespace CatApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/[controller]")]
public class CatController(
    ICatService catService,
    CatModelMapper catModelMapper) : ControllerBase
{
    // TODO: add sorting cats by their color and breed
    [HttpGet]
    public IActionResult GetAllCats()
    {
        return Ok(catService.GetAllCats().Select(catModelMapper.ToCatModel).ToList());
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
}