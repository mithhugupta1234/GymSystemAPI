using Microsoft.AspNetCore.Mvc;
using GymSystemAPI.Data;
using GymSystemAPI.Models;

namespace GymSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly GymDbContext _context;

    public AuthController(GymDbContext context)
    {
        _context = context;
    }

    // REGISTER API
    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        var existingUser = _context.Users
            .FirstOrDefault(x => x.Email == user.Email);

        if (existingUser != null)
        {
            return BadRequest("Email already exists");
        }

        _context.Users.Add(user);

        _context.SaveChanges();

        return Ok("User Registered Successfully");
    }

    // LOGIN API
    [HttpPost("login")]
    public IActionResult Login(User loginUser)
    {
        var user = _context.Users.FirstOrDefault(x =>
            x.Email == loginUser.Email &&
            x.Password == loginUser.Password);

        if (user == null)
        {
            return Unauthorized("Invalid Email or Password");
        }

        return Ok("Login Successful");
    }
}