using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using As.Park.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace As.Park.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase
{
    private readonly IOwnerService _OwnerService;

    public OwnerController(IOwnerService ownerService)
    {
        _OwnerService = ownerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _OwnerService.GetList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(int id)
    {
        return Ok(await _OwnerService.Get(id));
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OwnerCreateDto ownerDto)
    {
        var id = await _OwnerService.Create(ownerDto);
        return Ok(id);
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] OwnerUpdateDto ownerDto)
    {
        var id = await _OwnerService.Update(ownerDto);
        return Ok(id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _OwnerService.Delete(id);
        return Ok(id);
    }

    [HttpGet("{id}/Cars")]

    public async Task<IActionResult> GetCarsList(int id)
    {
        return Ok(await _OwnerService.GetCarsList(id));
    }

    [HttpGet("{id}/Fines")]
    public async Task<IActionResult> ListFines(int id)
    {
        return Ok(await _OwnerService.ListFines(id));
    }
}
    
