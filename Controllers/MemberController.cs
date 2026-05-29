using Microsoft.AspNetCore.Mvc;
using GymSystemAPI.Data;
using GymSystemAPI.Models;
using GymSystemAPI.DTOs;

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

    // GET BY ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var member = _context.Members.Find(id);

        if (member == null)
        {
            return NotFound("Member not found");
        }

        return Ok(member);
    }

    // POST
    [HttpPost]
    public IActionResult Add(MemberDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var member = new Member
        {
            Name = dto.Name,
            Age = dto.Age,
            City = dto.City,
            Gender = dto.Gender,
            Email = dto.Email,
            Phone = dto.Phone,
            Department = dto.Department,
            Batch = dto.Batch,
            TrainerName = dto.TrainerName,
            JoiningDate = dto.JoiningDate,
            IsRegistered = dto.IsRegistered,
            PaymentDone = dto.PaymentDone
        };

        _context.Members.Add(member);

        _context.SaveChanges();

        return Ok(member);
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, MemberDto dto)
    {
        var member = _context.Members.Find(id);

        if (member == null)
        {
            return NotFound("Member not found");
        }

        member.Name = dto.Name;
        member.Age = dto.Age;
        member.City = dto.City;
        member.Gender = dto.Gender;
        member.Email = dto.Email;
        member.Phone = dto.Phone;
        member.Department = dto.Department;
        member.Batch = dto.Batch;
        member.TrainerName = dto.TrainerName;
        member.JoiningDate = dto.JoiningDate;
        member.IsRegistered = dto.IsRegistered;
        member.PaymentDone = dto.PaymentDone;

        _context.SaveChanges();

        return Ok(member);
    }

    // DELETE
    [HttpDelete]
    public IActionResult Delete(DeleteMemberDto dto)
    {
        var member = _context.Members
            .FirstOrDefault(x =>
                x.Id == dto.Id &&
                x.Phone == dto.Phone);

        if (member == null)
        {
            return NotFound("Member not found");
        }

        _context.Members.Remove(member);

        _context.SaveChanges();

        return Ok("Deleted Successfully");
    }
}