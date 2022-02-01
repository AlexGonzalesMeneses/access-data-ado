using System;
using System.Collections.Generic;
using Store.Ado.ManagerClasses;
using Store.Ado.Models;

namespace Store.Ado.QueryBuilders
{
    public class ProductQueryBuilder : SingleQueryBuilder
    {
        public const string ProductId = "Id";
        public const string Name = "Name";
        public const string Stock = "Stock";
        public const string CategoryId = "Id_Category";
        public override string[] Columns { get; } = { ProductId, Name, Stock, CategoryId };

        protected override string Table => "Products";

        protected override string Id => ProductId;

        public override string GetAllQuery => $"SELECT {Columns} FROM {Table}";
        public override string GetOneQuery => $"{GetAllQuery} WHERE {Id} = @{Id}";

        protected override List<string> MakeSetUpdate(object entity)
        {
            var product = entity as Product;
            var sets = new List<string>();

            if (product != null)
            {
                if (product.Name != null)
                {
                    sets.Add(Name);
                }

                if (product.Stock > 0)
                {
                    sets.Add(Stock);
                }

                if (product.CategoryId != Guid.Empty)
                {
                    sets.Add(CategoryId);
                }
            }

            return sets;
        }
    }
}