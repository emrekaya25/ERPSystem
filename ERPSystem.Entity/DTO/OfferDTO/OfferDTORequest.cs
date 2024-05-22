using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.OfferDTO
{
    public class OfferDTORequest:BaseRequestDTO
    {
        public Int64? Id { get; set; }
        public string? SupplierName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public Int64? StatusId { get; set; }
        public Int64? ApproverUserId { get; set; }
        public Int64? RequestId { get; set; }
    }
}
