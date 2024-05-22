using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.LoginDTO
{
    public class LoginDTOResponse
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public string Token { get; set; }
        public List<string> RoleName { get; set; }
        public Int64 CompanyId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string CompanyName { get; set; }
        public string UserImage { get; set; }
    }
}
