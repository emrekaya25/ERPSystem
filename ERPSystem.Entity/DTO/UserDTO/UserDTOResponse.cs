using ERPSystem.Entity.Base;
using ERPSystem.Entity.DTO.RoleDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.UserDTO
{
    public class UserDTOResponse:BaseResponseDTO
    {
        public Int64 Id { get; set; }
        public Int64 DepartmentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string DepartmentName { get; set; }
        public string CompanyName { get; set; }
        public List<RoleDTOResponse> Roles { get; set; }

    }
}
