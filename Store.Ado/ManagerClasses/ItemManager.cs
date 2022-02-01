using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Store.Ado.Configurations;
using Store.Ado.Models;

namespace Store.Ado.ManagerClasses
{
    public static class ItemManager
    {
        public static List<Item> GetItems()
        {
            List<Item> items = new List<Item>();

            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.GET_ITEMS_SQL, conn))
                {
                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            items.Add(new Item
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                UnitPrice = reader.GetFieldValue<decimal>("Price"),
                                Quantity = reader.GetFieldValue<int>("Quantity"),
                                ProductId = reader.GetFieldValue<Guid>("Product_Id")
                            });
                        }
                    }
                }
            }

            return items;
        }

        public static Item GetItem(Guid id)
        {
            Item item = null;

            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.GET_ITEM_BY_ID_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            item = new Item
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                UnitPrice = reader.GetFieldValue<decimal>("Price"),
                                Quantity = reader.GetFieldValue<int>("Quantity"),
                                ProductId = reader.GetFieldValue<Guid>("Product_Id")
                            };
                        }
                    }
                }
            }

            return item;
        }

        public static void InsertItem(Item item)
        {
            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.INSERT_ITEM_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command.Parameters.AddWithValue("@Price", item.UnitPrice);
                    command.Parameters.AddWithValue("@Product_Id", item.ProductId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool DeleteItem(Guid id)
        {
            bool success = false;

            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.DELETE_ITEM_BY_ID_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    success = command.ExecuteNonQuery() > 0;
                }
            }

            return success;
        }

        public static void UpdateItem(Item item)
        {
            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.UPDATE_ITEM_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command.Parameters.AddWithValue("@Price", item.UnitPrice);
                    command.Parameters.AddWithValue("@Product_Id", item.ProductId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}