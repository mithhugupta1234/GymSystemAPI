using System.Collections.Generic;
using GymSystemAPI.Models;
using GymSystemAPI.Repositories;

namespace GymSystemAPI.Services;

public class StaffService : IStaffService
{
    private readonly IStaffRepository _repository;

    public StaffService(IStaffRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Staff> GetAll()
    {
        return _repository.GetAll();
    }

    public Staff Add(Staff s)
    {
        return _repository.Add(s);
    }

    public Staff? Update(int id, Staff updatedStaff)
    {
        return _repository.Update(id, updatedStaff);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}
