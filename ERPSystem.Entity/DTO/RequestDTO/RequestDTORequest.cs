using ERPSystem.Entity.Base;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.RequestDTO
{
    public class RequestDTORequest:BaseRequestDTO
    {
        public Int64? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Quantity { get; set; }
        public Int64? ProductId { get; set; }
        public Int64? UnitId { get; set; }
        public Int64? RequesterId { get; set; }
        public Int64? ApproverId { get; set; }
        public Int64? StatusId { get; set; }
        public Int64? CompanyId { get; set; }
    }
}
