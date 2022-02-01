using System;

namespace Store.Ado.Models
{
    public class Order : BaseEntity
    {
        public double Total { get; set; }
        public Guid ItemId { get; set; }
    }
}