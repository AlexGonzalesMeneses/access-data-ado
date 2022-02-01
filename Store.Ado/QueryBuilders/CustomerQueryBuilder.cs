using System;
using System.Collections.Generic;
using Store.Ado.ManagerClasses;
using Store.Ado.Models;

namespace Store.Ado.QueryBuilders
{
    public class CustomerQueryBuilder : SingleQueryBuilder
    {
        public const string CustomerId = "Id";
        public const string FirstName = "FirstName";
        public const string LastName = "LastName";
        public const string Phone = "Phone";
        public const string Address = "Address";
        public const string Nit = "Nit";
        public const string UserId = "Id_User";

        public override string[] Columns { get; } = { CustomerId, FirstName, LastName, Phone, Address, Nit, UserId };

        protected override string Table => "Customers";

        protected override string Id => CustomerId;

        protected override List<string> MakeSetUpdate(object entity)
        {
            var information = entity as Customer;
            var sets = new List<string>();

            if (information != null)
            {
                if (information.FirstName != null)
                {
                    sets.Add(FirstName);
                }

                if (information.LastName != null)
                {
                    sets.Add(LastName);
                }

                if (information.Phone != null)
                {
                    sets.Add(Phone);
                }

                if (information.Address != null)
                {
                    sets.Add(Address);
                }

                if (information.Nit != null)
                {
                    sets.Add(Nit);
                }

                if (information.UserId != Guid.Empty)
                {
                    sets.Add(UserId);
                }
            }

            return sets;
        }
    }
}