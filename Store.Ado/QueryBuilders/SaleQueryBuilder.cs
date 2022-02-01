using Store.Ado.ManagerClasses;
using Store.Ado.Models;
using System;
using System.Collections.Generic;

namespace Store.Ado.QueryBuilders
{
    public class SaleQueryBuilder : SingleQueryBuilder
    {
        public const string SaleId = "Id";
        public const string OrderId = "Id_Order";
        public const string UserId = "Id_User";
        public const string Date = "Date";

        public override string[] Columns { get; } = { SaleId, OrderId, UserId, Date };

        protected override string Table => "Sales";

        protected override string Id => SaleId;

        protected override List<string> MakeSetUpdate(object entity)
        {
            var information = entity as Sale;
            var sets = new List<string>();

            if (information != null)
            {
                if (information.OrderId != Guid.Empty)
                {
                    sets.Add(OrderId);
                }

                if (information.UserId != Guid.Empty)
                {
                    sets.Add(UserId);
                }

                if (information.Date != DateTime.MinValue)
                {
                    sets.Add(Date);
                }
            }

            return sets;
        }
    }
}