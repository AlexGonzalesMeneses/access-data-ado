using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Store.Ado.ManagerClasses
{
    public abstract class DataManagerBase
    {
        public string ConnectionString { get; set; }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public virtual List<T> GetRecords<T>(string sql, IEntityCreator<T> creator)
        {
            var results = new List<T>();
            PerformExecuteReader(sql, creator.FillParameters, reader =>
            {
                while (reader.Read())
                {
                    results.Add(creator.CreateEntity(reader));
                }
            });

            return results;
        }

        public virtual T ExecuteNonQuery<T>(string sql, IEntityCreator<T> creator)
        {
            PerformExecuteNonQuery(sql, creator.FillParameters);

            return creator.CreateEntity(null);
        }

        public void RunQuery(string sql, Action<SqlCommand> doNext)
        {
            using (var cnn = CreateConnection())
            {
                using (var cmd = new SqlCommand(sql, cnn))
                {
                    cnn.Open();
                    doNext(cmd);
                }
            }
        }

        public void PerformExecuteReader(string sql, Action<SqlCommand> addParams, Action<SqlDataReader> doRead)
        {
            RunQuery(sql, cmd =>
            {
                addParams(cmd);
                using (var reader = cmd.ExecuteReader())
                {
                    doRead(reader);
                }
            });
        }

        public int PerformExecuteNonQuery(string sql, Action<SqlCommand> addParams)
        {
            var result = 0;
            RunQuery(sql, cmd =>
            {
                addParams(cmd);
                result = cmd.ExecuteNonQuery();
            });

            return result;
        }

        public object GetIdentityExecuteNonQuery(string sql, Action<SqlCommand> addParams)
        {
            object identity = null;

            RunQuery(sql, (cmd) =>
            {
                addParams(cmd);

                var dataSet = new DataSet();

                cmd.CommandText += ";SELECT @@ROWCOUNT As RowsAffected, SCOPE_IDENTITY() AS IdentityGenerated";

                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dataSet);
                    if (dataSet.Tables.Count > 0)
                    {
                        identity = dataSet.Tables[0].Rows[0]["IdentityGenerated"];
                    }
                }
            });

            return identity;
        }
    }
}