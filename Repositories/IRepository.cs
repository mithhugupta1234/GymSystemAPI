using System.Collections.Generic;

namespace GymSystemAPI.Repositories;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();

    T? Get(int id);

    T Add(T entity);

    T? Update(int id, T entity);

    bool Delete(int id);
}
