namespace GymSystemAPI.Models;

public class MembershipPlan
{
    public int Id { get; set; }

    public string PlanName { get; set; } = "";

    public int DurationMonths { get; set; }

    public int Price { get; set; }

    public string Features { get; set; } = "";

    public bool IsActive { get; set; } = true;
}