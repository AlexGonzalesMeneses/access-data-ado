using System;
using System.Collections.Generic;
using Store.Ado.Models;
using System.Data.SqlClient;
using Store.Ado.Configurations;
using Store.Ado.Components;
using System.Data;

namespace Store.Ado.ManagerClasses
{
    public static class ProductManager
    {
        public static List<Product> GetProduct()
        {
            List<Product> products = new List<Product>();

            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.GET_PRODUCTS_SQL, conn))
                {
                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                Name = reader.GetFieldValue<string>("Name"),
                                Stock = reader.GetFieldValue<int>("Stock"),
                                CategoryId = reader.GetFieldValue<Guid>("Category_Id")
                            });
                        }
                    }
                }
            }

            return products;
        }

        public static Product GetProduct(Guid id)
        {
            Product product = null;

            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.GET_PRODUCT_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                Name = reader.GetFieldValue<string>("Name"),
                                Stock = reader.GetFieldValue<int>("Stock"),
                                CategoryId = reader.GetFieldValue<Guid>("Category_Id")
                            };
                        };
                    }
                }
            }

            return product;
        }

        public static void AddProduct(Product product)
        {
            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.INSERT_PRODUCT_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@Category_Id", product.CategoryId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool UpdateProduct(Product product)
        {
            bool result = false;

            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.UPDATE_PRODUCT_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@CategoryId", product.CategoryId);

                    result = command.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public static bool DeleteProduct(Guid id)
        {
            bool result = false;

            using (var conn = new SqlConnection(Connections.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(Queries.DELETE_PRODUCT_BY_ID_SQL, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    result = command.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }
    }
}