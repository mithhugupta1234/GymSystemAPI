namespace GymSystemAPI.Models;

public class Staff
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public int Age { get; set; }

    public string Gender { get; set; } = "";

    public string Role { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Email { get; set; } = "";

    public int Salary { get; set; }

    public DateTime JoiningDate { get; set; }

    public bool IsActive { get; set; } = true;
}