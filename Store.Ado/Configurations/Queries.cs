using System;

namespace Store.Ado.Configurations
{
    public class Queries
    {
        public const string GET_PRODUCTS_SQL = "SELECT Id, Name, Stock, Category_Id FROM Products";
        public const string GET_PRODUCT_SQL = "SELECT Id, Name, Stock, Category_Id FROM Products WHERE Id = @Id";
        public const string UPDATE_PRODUCT_SQL = "UPDATE Products SET Name = @Name, Stock = @Stock, Category_Id = @CategoryId WHERE Id = @Id";
        public const string DELETE_PRODUCT_BY_ID_SQL = "DELETE FROM Products WHERE Id = @Id";
        public const string INSERT_PRODUCT_SQL = "INSERT INTO Products (Id, Name, Stock, Category_Id) VALUES (@Id, @Name, @Stock, @Category_Id)";

        public const string GET_CATEGORIES_SQL = "SELECT Id, Name FROM Categories";
        public const string INSERT_CATEGORY_SQL = "INSERT INTO Categories (Name) VALUES (@Name)";
        public const string UPDATE_CATEGORY_SQL = "UPDATE Categories SET Name = @Name WHERE Id = @Id";
        public const string DELETE_CATEGORY_BY_ID_SQL = "DELETE FROM Categories WHERE Id = @Id";


        public const string GET_ITEMS_SQL = "SELECT Id, Price, Quantity, Product_Id FROM Items";
        public const string INSERT_ITEM_SQL = "INSERT INTO Items (Id, Price, Quantity, Product_Id) VALUES (@Id, @Price, @Quantity, @Product_Id)";
        public const string UPDATE_ITEM_SQL = "UPDATE Items SET Price = @Price, Quantity = @Quantity, Product_Id = @Product_Id WHERE Id = @Id";
        public const string DELETE_ITEM_BY_ID_SQL = "DELETE FROM Items WHERE Id = @Id";
        public const string GET_ITEM_BY_ID_SQL = "SELECT Id, Quantity, Price, Product_Id FROM Items WHERE Id = @Id";


        public const string GET_ORDERS_SQL = "SELECT Id, Item_Id, Total_Price FROM Orders";
        public const string INSERT_ORDER_SQL = "INSERT INTO Orders (Item_Id, Total_Price) VALUES (@Item_Id, @Total_Price)";
        public const string UPDATE_ORDER_SQL = "UPDATE Orders SET Item_Id = @Item_Id, Total_Price = @Total_Price WHERE Id = @Id";
        public const string DELETE_ORDER_BY_ID_SQL = "DELETE FROM Orders WHERE Id = @Id";
        public const string GET_ORDER_BY_SQL = "SELECT Id, Item_Id, Total_Price FROM Orders WHERE Id = @Id";
    }
}