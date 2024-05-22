using ERPSystem.Entity.Base;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.UserDTO
{
    public class UserDTORequest:BaseRequestDTO
    {
        public Int64? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Image { get; set; }
        public string? CompanyName { get; set; }
        public Int64? DepartmentId { get; set; }
        public Int64? CompanyId { get; set; }
    }
}
