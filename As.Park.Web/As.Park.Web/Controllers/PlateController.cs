using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace As.Park.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlateController : ControllerBase
{
    private readonly IPlateService _plateService;

    public PlateController(IPlateService plateService)
    {
        _plateService = plateService;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _plateService.GetList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(int id)
    {
        return Ok(await _plateService.Get(id));
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PlateCreateDto plateDto)
    {
        var id = await _plateService.Create(plateDto);
        return Ok(id);
    }

    [HttpPatch("{id}/car/{carId}")]
    public async Task<IActionResult> ChangeCar(int id, int carId)
    {
        await _plateService.ChangeCar(id, carId);
        return Ok(id);
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] PlateUpdateDto plateDto)
    {
        var id = await _plateService.Update(plateDto);
        return Ok(id);
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        await _plateService.Delete(id);
        return Ok(id);
    }

    //[HttpPost]
    //public async Task<IActionResult> Login([FromBody] PlateDto plateDto)
    //{
    //    return Ok(await _plateService.Login(plateDto));
    //}
}