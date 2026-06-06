using System.Collections.Generic;
using GymSystemAPI.Models;

namespace GymSystemAPI.Services;

public interface IStaffService
{
    IEnumerable<Staff> GetAll();

    Staff Add(Staff s);

    Staff? Update(int id, Staff updatedStaff);

    bool Delete(int id);
}
