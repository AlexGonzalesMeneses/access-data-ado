using System;

namespace Store.Ado.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}