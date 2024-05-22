using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.UnitDTO
{
    public class UnitDTORequest:BaseRequestDTO
    {
        public Int64? Id { get; set; }
        public string? Name { get; set; }
    }
}
