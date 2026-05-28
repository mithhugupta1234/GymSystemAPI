using Microsoft.AspNetCore.Mvc;
using GymSystemAPI.Data;
using GymSystemAPI.Models;

namespace GymSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainerController : ControllerBase
{
    private readonly GymDbContext _context;

    public TrainerController(GymDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Trainers.ToList());
    }

    // POST
    [HttpPost]
    public IActionResult Add(Trainer t)
    {
        t.Id = 0;

        _context.Trainers.Add(t);

        _context.SaveChanges();

        return Ok(t);
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Trainer updatedTrainer)
    {
        var trainer = _context.Trainers.Find(id);

        if (trainer == null)
        {
            return NotFound("Trainer not found");
        }

        trainer.Name = updatedTrainer.Name;
        trainer.Specialization = updatedTrainer.Specialization;

        _context.SaveChanges();

        return Ok(trainer);
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var data = _context.Trainers.Find(id);

        if (data == null)
        {
            return NotFound("Trainer not found");
        }

        _context.Trainers.Remove(data);

        _context.SaveChanges();

        return Ok("Deleted");
    }
}