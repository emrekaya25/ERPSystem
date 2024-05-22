using ERPSystem.Entity.Base;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.StockDetailDTO
{
    public class StockDetailDTORequest:BaseRequestDTO
    {
        public Int64? Id { get; set; }
        public decimal Quantity { get; set; }
        public Int64? StockId { get; set; }
        public Int64? ProcessTypeId { get; set; }
        public Int64? ReceiverId { get; set; }
        public Int64? DelivererId { get; set; }
    }
}
