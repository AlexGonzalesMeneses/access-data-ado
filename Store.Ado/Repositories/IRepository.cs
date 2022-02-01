using System.Collections.Generic;
using System;

namespace Store.Ado.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        bool Delete(T entity);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}