using Store.Ado.ManagerClasses;
using Store.Ado.Models;
using System;

namespace Store.Ado.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IRepository<Product>
    {
        public ProductRepository(ContextDB<Product> context, IEntityCreator<Product> creator, IQueryBuilder builder) : base(context, creator, builder)
        {
        }
    }
}