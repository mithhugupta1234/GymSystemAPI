using Microsoft.AspNetCore.Mvc;
using GymSystemAPI.Data;
using GymSystemAPI.Models;

namespace GymSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffController : ControllerBase
{
    private readonly GymDbContext _context;

    public StaffController(GymDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Staffs.ToList());
    }

    // POST
    [HttpPost]
    public IActionResult Add(Staff s)
    {
        s.Id = 0;

        _context.Staffs.Add(s);

        _context.SaveChanges();

        return Ok(s);
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Staff updatedStaff)
    {
        var staff = _context.Staffs.Find(id);

        if (staff == null)
        {
            return NotFound("Staff not found");
        }

        staff.Name = updatedStaff.Name;
        staff.Role = updatedStaff.Role;

        _context.SaveChanges();

        return Ok(staff);
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var data = _context.Staffs.Find(id);

        if (data == null)
        {
            return NotFound("Staff not found");
        }

        _context.Staffs.Remove(data);

        _context.SaveChanges();

        return Ok("Deleted");
    }
}