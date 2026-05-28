namespace GymSystemAPI.Models;

public class Attendance
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public string MemberName { get; set; } = "";

    public DateTime Date { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public bool Present { get; set; } = true;

    public string Status { get; set; } = "Checked In";
}