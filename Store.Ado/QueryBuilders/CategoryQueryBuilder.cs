using System.Collections.Generic;
using Store.Ado.ManagerClasses;
using Store.Ado.Models;

namespace Store.Ado.QueryBuilders
{
    public class CategoryQueryBuilder : SingleQueryBuilder
    {
        public const string CategoryId = "Id";
        public const string Name = "Name";

        public override string[] Columns { get; } = { CategoryId, Name };

        protected override string Table => "Categories";

        protected override string Id => CategoryId;

        protected override List<string> MakeSetUpdate(object entity)
        {
            var category = entity as Category;
            var sets = new List<string>();

            if (category != null)
            {
                if (category.Name != null)
                {
                    sets.Add(Name);
                }
            }

            return sets;
        }
    }
}