using System;

namespace Store.Ado.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
    }
}