using System;
using System.Collections.Generic;
using Store.Ado.ManagerClasses;
using Store.Ado.Models;

namespace Store.Ado.QueryBuilders
{
    public class ItemQueryBuilder : SingleQueryBuilder
    {
        public const string ItemId = "Id";
        public const string ProductId = "Id_Product";
        public const string UnitPrice = "Unit_Price";
        public const string Quantity = "Quantity";

        public override string[] Columns { get; } = { ItemId, ProductId, UnitPrice, Quantity };

        protected override string Table => "Items";

        protected override string Id => ItemId;

        protected override List<string> MakeSetUpdate(object entity)
        {
            var information = entity as Item;
            var sets = new List<string>();

            if (information != null)
            {
                if (information.ProductId != Guid.Empty)
                {
                    sets.Add(ProductId);
                }

                if (information.UnitPrice != 0)
                {
                    sets.Add(UnitPrice);
                }

                if (information.Quantity != 0)
                {
                    sets.Add(Quantity);
                }
            }

            return sets;
        }
    }
}