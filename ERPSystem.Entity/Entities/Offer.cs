using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class Offer:BaseEntity
    {
        public string SupplierName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Status Status { get; set; }
        public Int64 StatusId { get; set; }

        public User ApproverOfferUser { get; set; }
        public Int64? ApproverUserId { get; set; } = null;

        public Request Request { get; set; }
        public Int64 RequestId { get; set; }
    }
}
