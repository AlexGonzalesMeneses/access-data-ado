using Store.Ado.ManagerClasses;
using Store.Ado.Models;
using System;
using System.Collections.Generic;

namespace Store.Ado.QueryBuilders
{
    public class RoleQueryBuilder : SingleQueryBuilder
    {
        public const string RoleId = "Id";
        public const string Name = "Name";

        public override string[] Columns { get; } = { RoleId, Name };

        protected override string Table => "Roles";

        protected override string Id => RoleId;

        protected override List<string> MakeSetUpdate(object entity)
        {
            var information = entity as Role;
            var sets = new List<string>();

            if (information != null)
            {
                if (!string.IsNullOrEmpty(information.Name))
                {
                    sets.Add(Name);
                }
            }

            return sets;
        }
    }
}