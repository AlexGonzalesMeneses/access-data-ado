using Store.Ado.ManagerClasses;
using Store.Ado.Models;
using System;
using System.Collections.Generic;

namespace Store.Ado.QueryBuilders
{
    public class UserRoleQueryBuilder : SingleQueryBuilder
    {
        public const string UserRoleId = "Id";
        public const string UserId = "Id_User";
        public const string RoleId = "Id_Role";

        public override string[] Columns { get; } = { UserRoleId, UserId, RoleId };

        protected override string Table => "UserRoles";

        protected override string Id => UserRoleId;

        protected override List<string> MakeSetUpdate(object entity)
        {
            var information = entity as UserRole;
            var sets = new List<string>();

            if (information != null)
            {
                if (information.UserId != Guid.Empty)
                {
                    sets.Add(UserId);
                }

                if (information.RoleId != Guid.Empty)
                {
                    sets.Add(RoleId);
                }
            }

            return sets;
        }
    }
}