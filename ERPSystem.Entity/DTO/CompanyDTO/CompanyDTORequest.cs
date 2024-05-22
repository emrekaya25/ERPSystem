using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.CompanyDTO
{
    public class CompanyDTORequest:BaseRequestDTO
    {
        public Int64? Id { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
    }
}
