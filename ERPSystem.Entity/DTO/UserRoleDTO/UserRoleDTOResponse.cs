using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.UserRoleDTO
{
    public class UserRoleDTOResponse:BaseResponseDTO
    {
        public Int64 Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
