using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace As.Park.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FineController : ControllerBase
{
    private readonly IFineService _fineService;

    public FineController(IFineService fineService)
    {
        _fineService = fineService;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _fineService.GetList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(int id)
    {
        return Ok(await _fineService.Get(id));
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FineCreateDto fineDto)
    {
        var id = await _fineService.Create(fineDto);
        return Ok(id);
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] FineUpdateDto fineDto)
    {
        var id = await _fineService.Update(fineDto);
        return Ok(id);
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        await _fineService.Delete(id);
        return Ok(id);
    }

    //[HttpPost]
    //public async Task<IActionResult> Login([FromBody] FineDto fineDto)
    //{
    //    return Ok(await _fineService.Login(fineDto));
    //}
}