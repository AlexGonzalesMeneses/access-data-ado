using System;
using System.Data.SqlClient;

namespace Store.Ado.ManagerClasses
{
    public interface IEntityCreator<T>
    {
        public T Entity { get; set; }
        T CreateEntity(SqlDataReader reader);
        void FillParameters(SqlCommand cmd);
    }
}