using System.ComponentModel.DataAnnotations;

namespace GymSystemAPI.DTOs;

public class LoginDto
{
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";
}