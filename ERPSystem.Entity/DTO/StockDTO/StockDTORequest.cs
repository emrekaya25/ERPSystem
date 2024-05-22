using ERPSystem.Entity.Base;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.StockDTO
{
    public class StockDTORequest:BaseRequestDTO
    {
        public Int64? Id { get; set; }
        public decimal Quantity { get; set; }
        public Int64? ProductId { get; set; }
        public Int64? UnitId { get; set; }
        public Int64? DepartmentId { get; set; }
    }
}
