using System;

namespace Store.Ado.Models
{
    public class Sale : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime Date { get; set; }
    }
}