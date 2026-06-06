using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using GymSystemAPI.Models;
using GymSystemAPI.Services;

namespace GymSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffController : ControllerBase
{
    private readonly IStaffService _service;
    private readonly IMemoryCache _cache;

    public StaffController(IStaffService service, IMemoryCache cache)
    {
        _service = service;
        _cache = cache;
    }

    // GET ALL (supports pagination & filtering; cached full list for 60s)
    [HttpGet]
    public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null, [FromQuery] string? role = null)
    {
        const string key = "staff_all";

        if (!_cache.TryGetValue(key, out IEnumerable<Staff> fullList))
        {
            fullList = _service.GetAll();

            var options = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

            _cache.Set(key, fullList, options);
        }

        // Apply filtering
        var filtered = fullList;
        if (!string.IsNullOrWhiteSpace(search))
        {
            filtered = System.Linq.Enumerable.Where(filtered, s => (!string.IsNullOrEmpty(s.Name) && s.Name.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        if (!string.IsNullOrWhiteSpace(role))
        {
            filtered = System.Linq.Enumerable.Where(filtered, s => !string.IsNullOrEmpty(s.Role) && s.Role.Equals(role, StringComparison.OrdinalIgnoreCase));
        }

        var totalCount = System.Linq.Enumerable.Count(filtered);
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        var items = System.Linq.Enumerable.Skip(filtered, (page - 1) * pageSize).Take(pageSize);

        return Ok(new { items, totalCount, page, pageSize, totalPages });
    }

    // POST
    [HttpPost]
    public IActionResult Add(Staff s)
    {
        var created = _service.Add(s);
        // Invalidate cache after mutation
        _cache.Remove("staff_all");
        return Ok(created);
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Staff updatedStaff)
    {
        var updated = _service.Update(id, updatedStaff);

        if (updated == null)
            return NotFound("Staff not found");

        _cache.Remove("staff_all");
        return Ok(updated);
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var ok = _service.Delete(id);

        if (!ok)
            return NotFound("Staff not found");

        _cache.Remove("staff_all");
        return Ok("Deleted");
    }
}