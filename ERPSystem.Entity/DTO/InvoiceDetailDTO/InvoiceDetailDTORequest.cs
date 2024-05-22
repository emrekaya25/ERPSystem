using ERPSystem.Entity.Base;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.InvoiceDetailDTO
{
    public class InvoiceDetailDTORequest:BaseRequestDTO
    {
        public Int64? Id { get; set; }
        public Int64? InvoiceId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Sum { get; set; }
    }
}
