using System;
using System.Collections.Generic;
using Store.Ado.Models;

namespace Store.Ado.ManagerClasses
{
    public class ContextDB<T> : DataManagerBase where T : BaseEntity
    {
        IQueryBuilder queryBuilder;
        IEntityCreator<T> creator;

        public ContextDB(IQueryBuilder queryBuilder, IEntityCreator<T> creator)
        {
            this.queryBuilder = queryBuilder;
            this.creator = creator;
        }

        public List<T> GetAll()
        {
            creator.Entity = null;

            return GetRecords<T>(queryBuilder.GetAllQuery, creator);
        }

        public T GetById(Guid entity)
        {
            creator.Entity = null;

            return GetRecords<T>(queryBuilder.GetOneQuery, creator)[0];
        }

        public T Add(T entity)
        {
            creator.Entity = entity;

            return ExecuteNonQuery<T>(queryBuilder.InsertQuery, creator);
        }

        public T Update(T entity)
        {
            creator.Entity = entity;

            return ExecuteNonQuery<T>(queryBuilder.UpdateOneQuery(entity), creator);
        }

        public bool Delete(T entity)
        {
            creator.Entity = entity;

            return PerformExecuteNonQuery(queryBuilder.DeleteOneQuery, creator.FillParameters) > 0;
        }
    }
}