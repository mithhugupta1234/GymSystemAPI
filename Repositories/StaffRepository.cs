using System.Collections.Generic;
using System.Linq;
using GymSystemAPI.Data;
using GymSystemAPI.Models;

namespace GymSystemAPI.Repositories;

public class StaffRepository : IStaffRepository
{
    private readonly GymDbContext _context;

    public StaffRepository(GymDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Staff> GetAll()
    {
        return _context.Staffs.ToList();
    }

    public Staff? Get(int id)
    {
        return _context.Staffs.Find(id);
    }

    public Staff Add(Staff entity)
    {
        entity.Id = 0;
        _context.Staffs.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Staff? Update(int id, Staff entity)
    {
        var staff = _context.Staffs.Find(id);
        if (staff == null)
            return null;

        staff.Name = entity.Name;
        staff.Role = entity.Role;

        _context.SaveChanges();

        return staff;
    }

    public bool Delete(int id)
    {
        var data = _context.Staffs.Find(id);
        if (data == null)
            return false;

        _context.Staffs.Remove(data);
        _context.SaveChanges();
        return true;
    }
}
