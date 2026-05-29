using System.ComponentModel.DataAnnotations;

namespace GymSystemAPI.DTOs;

public class RegisterDto
{
    [Required]
    public string Name { get; set; } = "";

    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";
}