using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Store.Ado.Configurations;
using Store.Ado.Models;

namespace Store.Ado.ManagerClasses
{
    public static class OrderManager
    {
        public static List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.GET_ORDERS_SQL, conn))
                {
                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                ItemId = reader.GetFieldValue<Guid>("Id_Item"),
                                Total = (double)reader.GetFieldValue<decimal>("Total_Price")
                            });
                        }
                    }
                }
            }

            return orders;
        }

        public static Order GetOrder(Guid id)
        {
            Order order = null;

            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.GET_ORDER_BY_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = new Order
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                ItemId = reader.GetFieldValue<Guid>("Item_Id"),
                                Total = (double)reader.GetFieldValue<decimal>("Total_Price")
                            };
                        }
                    }
                }
            }

            return order;
        }

        public static void AddOrder(Order order)
        {
            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.INSERT_ORDER_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", order.Id);
                    command.Parameters.AddWithValue("@Item_Id", order.ItemId);
                    command.Parameters.AddWithValue("@Total_Price", order.Total);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateOrder(Order order)
        {
            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.UPDATE_ORDER_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", order.Id);
                    command.Parameters.AddWithValue("@Item_Id", order.ItemId);
                    command.Parameters.AddWithValue("@Total_Price", order.Total);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteOrder(Guid id)
        {
            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.DELETE_ORDER_BY_ID_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}