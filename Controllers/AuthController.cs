using GymSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

    var claims = new[]
    {
        new Claim(ClaimTypes.Name, user.Email)
    };

    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(
            _configuration["Jwt:Key"]!
        )
    );

    var creds = new SigningCredentials(
        key,
        SecurityAlgorithms.HmacSha256
    );

    var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.Now.AddHours(1),
        signingCredentials: creds
    );

    return Ok(new
    {
        token = new JwtSecurityTokenHandler()
            .WriteToken(token)
    });
}