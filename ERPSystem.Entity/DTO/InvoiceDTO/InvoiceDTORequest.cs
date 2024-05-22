using ERPSystem.Entity.Base;
using ERPSystem.Entity.DTO.InvoiceDetailDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.InvoiceDTO
{
    public class InvoiceDTORequest:BaseRequestDTO
    {
        public Int64? Id { get; set; }
        public Int64? CompanyId { get; set; }
        public DateTime? InvoiceDate { get; set; } = null;
        public int? InvoiceNo { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierPhone { get; set; }
        public string? SupplierAddress { get; set; }
        public string? SupplierMail { get; set; }
        public string? CompanyName { get; set; }
        public List<InvoiceDetailDTORequest> InvoiceDetails { get; set; } = null;
    }
}
