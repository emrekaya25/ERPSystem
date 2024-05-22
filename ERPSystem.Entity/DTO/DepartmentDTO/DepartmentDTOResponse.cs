using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.DepartmentDTO
{
    public class DepartmentDTOResponse:BaseResponseDTO
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64 CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
