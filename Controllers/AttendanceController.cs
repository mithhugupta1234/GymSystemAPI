using Microsoft.AspNetCore.Mvc;
using GymSystemAPI.Data;
using GymSystemAPI.Models;

namespace GymSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly GymDbContext _context;

    public AttendanceController(GymDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Attendances.ToList());
    }

    // POST
    [HttpPost]
    public IActionResult Add(Attendance a)
    {
        a.Id = 0;

        _context.Attendances.Add(a);

        _context.SaveChanges();

        return Ok(a);
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Attendance updatedAttendance)
    {
        var data = _context.Attendances.Find(id);

        if (data == null)
        {
            return NotFound("Attendance not found");
        }

        data.MemberId = updatedAttendance.MemberId;
        data.Date = updatedAttendance.Date;
        data.CheckIn = updatedAttendance.CheckIn;
        data.CheckOut = updatedAttendance.CheckOut;

        _context.SaveChanges();

        return Ok(data);
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var data = _context.Attendances.Find(id);

        if (data == null)
        {
            return NotFound("Attendance not found");
        }

        _context.Attendances.Remove(data);

        _context.SaveChanges();

        return Ok("Deleted");
    }
}