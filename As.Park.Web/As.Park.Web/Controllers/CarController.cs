using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using As.Park.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace As.Park.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCarsByMakeModel([FromQuery] string search = null)
    {
        if (string.IsNullOrEmpty(search))
        {
            return Ok(await _carService.GetList());
        }
        
        return Ok(await _carService.Search(search));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(int id)
    {
        return Ok(await _carService.Get(id));
    }

    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CarCreateDto carDto)
    {
        var id = await _carService.Create(carDto);
        return Ok(id);
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CarUpdateDto carDto)
    {
        await _carService.Update(id, carDto);
        return Ok(id);
    }
    
    [HttpDelete("{id}")]
    
    public async Task<IActionResult> Delete(int id)
    {
        await _carService.Delete(id);
        return Ok(id);
    }
    
    [HttpPatch("{id}/owner/{ownerId}")]
    public async Task<IActionResult> ChangeOwner(int id, int ownerId)
    {
        await _carService.ChangeOwner(id, ownerId);
        return Ok(id);
    }

    [HttpGet("{id}/vignette")]

    public async Task<IActionResult> ListVignette(int id)
    {
        return Ok(await _carService.ListVignette(id));
    }

    [HttpGet("{id}/fines")]

    public async Task<IActionResult> ListFines(int id)
    {
        return Ok(await _carService.ListFines(id));
    }
    // [HttpPost]
    // public async Task<IActionResult> Login([FromBody] CarDto carDto)
    // {
    //     return Ok(await _carService.Login(carDto));
    // }
}