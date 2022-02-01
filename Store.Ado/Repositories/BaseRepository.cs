using System;
using System.Collections.Generic;
using Store.Ado.Configurations;
using Store.Ado.ManagerClasses;
using Store.Ado.Models;

namespace Store.Ado.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ContextDB<T> context;

        public BaseRepository(ContextDB<T> context, IEntityCreator<T> creator, IQueryBuilder builder)
        {
            context = new ContextDB<T>(builder, creator) { ConnectionString = Connections.ConnectionString };
        }

        public T Add(T entity)
        {
            context.Add(entity);
            return entity;
        }

        public bool Delete(T entity)
        {
            return context.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return context.GetAll();
        }

        public T GetById(Guid id)
        {
            return context.GetById(id);
        }

        public T Update(T entity)
        {
            return context.Update(entity);
        }
    }
}