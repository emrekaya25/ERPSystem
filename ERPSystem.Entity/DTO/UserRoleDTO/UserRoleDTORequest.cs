using ERPSystem.Entity.Base;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.UserRoleDTO
{
    public class UserRoleDTORequest:BaseRequestDTO
    {
        public Int64? Id { get; set; }
        public Int64? UserId { get; set; }
        public Int64? RoleId { get; set; }
    }
}
