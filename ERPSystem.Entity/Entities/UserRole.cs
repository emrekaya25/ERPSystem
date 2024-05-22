using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class UserRole:BaseEntity
    {
        public User User { get; set; }
        public Int64 UserId { get; set; }
        public Role Role { get; set; }
        public Int64 RoleId { get; set;}
    }
}
