using Microsoft.AspNetCore.Mvc;
using GymSystemAPI.Data;
using GymSystemAPI.Models;

namespace GymSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    private readonly GymDbContext _context;

    public MemberController(GymDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Members.ToList());
    }

    // POST
    [HttpPost]
    public IActionResult Add(Member m)
    {
        m.Id = 0;

        _context.Members.Add(m);

        _context.SaveChanges();

        return Ok(m);
    }

    // PUT (UPDATE)
    [HttpPut("{id}")]
    public IActionResult Update(int id, Member updatedMember)
    {
        var member = _context.Members.Find(id);

        if (member == null)
            return NotFound("Member not found");

        member.Name = updatedMember.Name;
        member.Age = updatedMember.Age;
        member.City = updatedMember.City;

        _context.SaveChanges();

        return Ok(member);
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var member = _context.Members.Find(id);

        if (member == null)
            return NotFound("Member not found");

        _context.Members.Remove(member);

        _context.SaveChanges();

        return Ok("Deleted");
    }
}