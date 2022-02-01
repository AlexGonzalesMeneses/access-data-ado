using System;

namespace Store.Ado.Models
{
    public class UserRole : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}