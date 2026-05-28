using Microsoft.AspNetCore.Mvc;
using GymSystemAPI.Data;
using GymSystemAPI.Models;

namespace GymSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembershipPlanController : ControllerBase
{
    private readonly GymDbContext _context;

    public MembershipPlanController(GymDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.MembershipPlans.ToList());
    }

    // POST
    [HttpPost]
    public IActionResult Add(MembershipPlan plan)
    {
        plan.Id = 0;

        _context.MembershipPlans.Add(plan);

        _context.SaveChanges();

        return Ok(plan);
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, MembershipPlan updatedPlan)
    {
        var plan = _context.MembershipPlans.Find(id);

        if (plan == null)
            return NotFound("Plan not found");

        plan.PlanName = updatedPlan.PlanName;
        plan.Price = updatedPlan.Price;

        _context.SaveChanges();

        return Ok(plan);
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var data = _context.MembershipPlans.Find(id);

        if (data == null)
            return NotFound("Plan not found");

        _context.MembershipPlans.Remove(data);

        _context.SaveChanges();

        return Ok("Deleted");
    }
}