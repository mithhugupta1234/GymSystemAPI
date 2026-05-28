namespace GymSystemAPI.Models;

public class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public int Age { get; set; }

    public string City { get; set; } = "";

    public string Gender { get; set; } = "";

    public string Email { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Department { get; set; } = "";

    public string Batch { get; set; } = "";

    public string TrainerName { get; set; } = "";

    public DateTime JoiningDate { get; set; }

    public bool IsRegistered { get; set; } = true;

    public bool PaymentDone { get; set; } = false;
}