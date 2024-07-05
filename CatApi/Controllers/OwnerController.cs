using Bll.Services;
using CatApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CatApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class OwnerController(
    OwnerService ownerService,
    OwnerModelMapper ownerModelMapper) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllOwners()
    {
        var owners = ownerService.GetAllOwners();

        return Ok(owners.Select(ownerModelMapper.ToOwnerModel));
    }
}