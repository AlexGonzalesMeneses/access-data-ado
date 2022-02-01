using System;

namespace Store.Ado.Models
{
    public class Item : BaseEntity
    {
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}