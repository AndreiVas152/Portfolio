using As.Park.Services.Contracts;
using As.Park.Services.Dto;
using As.Park.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace As.Park.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _userService.GetList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(int id)
    {
        return Ok(await _userService.Get(id));
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateDto userDto)
    {
        var id = await _userService.Create(userDto);
        return Ok(id);
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] UserUpdateDto userDto)
    {
        var id = await _userService.Update(userDto);
        return Ok(id);
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        await _userService.Delete(id);
        return Ok(id);
    }

    [HttpGet("{id}/Fines")]
    public async Task<IActionResult> ListFines(int id)
    {
        return Ok(await _userService.ListFines(id));
    }
    //[HttpPost]
    //public async Task<IActionResult> Login([FromBody] UserDto userDto)
    //{
    //    return Ok(await _userService.Login(userDto));
    //}
}