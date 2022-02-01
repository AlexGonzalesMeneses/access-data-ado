using Store.Ado.ManagerClasses;
using Store.Ado.Models;
using System;
using System.Collections.Generic;

namespace Store.Ado.QueryBuilders
{
    public class OrderQueryBuilder : SingleQueryBuilder
    {
        public const string OrderId = "Id";
        public const string ItemId = "Id_Item";
        public const string TotalPrice = "Total_Price";

        public override string[] Columns { get; } = { OrderId, ItemId, TotalPrice };

        protected override string Table => "Orders";

        protected override string Id => OrderId;

        protected override List<string> MakeSetUpdate(object entity)
        {
            var information = entity as Order;
            var sets = new List<string>();

            if (information != null)
            {
                if (information.ItemId != Guid.Empty)
                {
                    sets.Add(ItemId);
                }

                if (information.Total != 0)
                {
                    sets.Add(TotalPrice);
                }
            }

            return sets;
        }
    }
}