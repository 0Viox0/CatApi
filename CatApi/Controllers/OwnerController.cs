using Asp.Versioning;
using Bll.Services.User;
using CatApi.Mappers;
using CatApi.Models.Owner;
using Microsoft.AspNetCore.Mvc;

namespace CatApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class OwnerController(
    IOwnerService ownerService,
    OwnerModelMapper ownerModelMapper) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllOwners()
    {
        var owners = ownerService.GetAllOwners();

        return Ok(owners.Select(ownerModelMapper.ToOwnerModel));
    }

    [HttpGet("{id}")]
    public IActionResult GetOwnerById(int id)
    {
        var owner = ownerService.GetOwnerById(id);

        return Ok(ownerModelMapper.ToOwnerIdModel(owner));
    }

    [HttpPost]
    public IActionResult CreateOwner(OwnerCreationModel ownerCreationModel)
    {
        var createdOwner = ownerService
            .CreateOwner(ownerModelMapper.ToOwnerCreationDto(ownerCreationModel));

        return Created(
            HttpContext.Request.Path,
            ownerModelMapper.ToOwnerIdModel(createdOwner));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOwner(int id)
    {
        var deletedOwner = ownerService.DeleteOwnerById(id);

        return Ok(ownerModelMapper.ToOwnerIdModel(deletedOwner));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOwner(int id, OwnerCreationModel ownerUpdateModel)
    {
        var ownerIdDto = ownerService.UpdateOwnerWithId(id, ownerModelMapper.ToOwnerCreationDto(ownerUpdateModel));

        return Ok(ownerModelMapper.ToOwnerIdModel(ownerIdDto));
    }

    [HttpPut("{ownerId}/owns-cat/{catId}")]
    public IActionResult AssignCatToOwner(int ownerId, int catId)
    {
        var ownerIdDto = ownerService.AssignCatToOwner(ownerId, catId);

        return Ok(ownerModelMapper.ToOwnerIdModel(ownerIdDto));
    }

    [HttpDelete("{ownerId}/disowns-cat/{catId}")]
    public IActionResult DisownCatFromOwner(int ownerId, int catId)
    {
        var ownerIdDto = ownerService.DisownCatFromOwner(ownerId, catId);

        return Ok(ownerModelMapper.ToOwnerIdModel(ownerIdDto));
    }
}