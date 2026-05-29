using System.ComponentModel.DataAnnotations;

namespace GymSystemAPI.DTOs;

public class MemberDto
{
    [Required]
    public string Name { get; set; } = "";

    [Range(18, 60)]
    public int Age { get; set; }

    [Required]
    public string City { get; set; } = "";

    [Required]
    public string Gender { get; set; } = "";

    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    public string Phone { get; set; } = "";

    [Required]
    public string Department { get; set; } = "";

    [Required]
    public string Batch { get; set; } = "";

    [Required]
    public string TrainerName { get; set; } = "";

    public DateTime JoiningDate { get; set; }

    public bool IsRegistered { get; set; }

    public bool PaymentDone { get; set; }
}