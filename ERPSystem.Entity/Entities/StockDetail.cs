using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class StockDetail:BaseEntity
    {
        public decimal Quantity { get; set; }
        public Stock Stock { get; set; }
        public Int64 StockId { get; set; }
        public ProcessType ProcessType { get; set; }
        public Int64 ProcessTypeId { get; set; }
        public User? Receiver { get; set; }
        public Int64? ReceiverId { get; set; }
        public User? Deliverer { get; set; }
        public Int64? DelivererId { get; set; }
    }
}
