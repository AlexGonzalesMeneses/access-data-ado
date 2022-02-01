using System;

namespace Store.Ado.ManagerClasses
{
    public interface IQueryBuilder
    {
        string[] Columns { get; }
        string GetAllQuery { get; }
        string GetOneQuery { get; }
        string InsertQuery { get; }
        string UpdateOneQuery(object entity);
        string DeleteOneQuery { get; }
    }
}