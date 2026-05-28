namespace GymSystemAPI.Models;

public class Trainer
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public int Age { get; set; }

    public string Gender { get; set; } = "";

    public string Specialization { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Email { get; set; } = "";

    public int ExperienceYears { get; set; }

    public int Salary { get; set; }

    public bool IsAvailable { get; set; } = true;
}