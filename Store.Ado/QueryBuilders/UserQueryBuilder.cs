using Store.Ado.ManagerClasses;
using Store.Ado.Models;
using System;
using System.Collections.Generic;

namespace Store.Ado.QueryBuilders
{
    public class UserQueryBuilder : SingleQueryBuilder
    {
        public const string UserId = "Id";
        public const string Username = "User_Name";
        public const string Password = "Password";
        public const string Email = "Email";

        public override string[] Columns { get; } = { UserId, Username, Password, Email };

        protected override string Table => "Users";

        protected override string Id => UserId;

        protected override List<string> MakeSetUpdate(object entity)
        {
            var information = entity as User;
            var sets = new List<string>();

            if (information != null)
            {
                if (!string.IsNullOrEmpty(information.Username))
                {
                    sets.Add(Username);
                }

                if (!string.IsNullOrEmpty(information.Password))
                {
                    sets.Add(Password);
                }

                if (!string.IsNullOrEmpty(information.Email))
                {
                    sets.Add(Email);
                }
            }

            return sets;
        }
    }
}