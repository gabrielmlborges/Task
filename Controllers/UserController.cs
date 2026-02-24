using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers;


[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }
    [HttpPost]

    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        if (user == null) return BadRequest("Invalid data");
        var createdUser = await _userService.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
    }
}