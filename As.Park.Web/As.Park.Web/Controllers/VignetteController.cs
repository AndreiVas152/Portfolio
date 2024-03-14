using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace As.Park.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VignetteController : ControllerBase
{
    private readonly IVignetteService _vignetteservice;

    public VignetteController(IVignetteService vignetteService)
    {
        _vignetteservice = vignetteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _vignetteservice.GetList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(int id)
    {
        return Ok(await _vignetteservice.Get(id));
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VignetteCreateDto vignetteDto)
    {
        var id = await _vignetteservice.Create(vignetteDto);
        return Ok(id);
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] VignetteUpdateDto vignetteDto)
    {
        var id = await _vignetteservice.Update(vignetteDto);
        return Ok(id);
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        await _vignetteservice.Delete(id);
        return Ok(id);
    }

    [HttpGet("Validate")]

    public async Task<IActionResult> GetValidity([FromQuery]string licensePlate)
    {
        return Ok(await _vignetteservice.GetValidity(licensePlate));
    }

    // GET/API/
    //[HttpPost]
    //public async Task<IActionResult> Login([FromBody] VignetteDto vignetteDto)
    //{
    //    return Ok(await _vignetteService.Login(vignetteDto));
    //}
}