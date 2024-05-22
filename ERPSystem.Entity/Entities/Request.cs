using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class Request:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }

        public Product Product { get; set; }
        public Int64 ProductId { get; set; }

        public Unit Unit { get; set; }
        public Int64 UnitId { get; set; }

        public User RequesterUser { get; set; }
        public Int64 RequesterId { get; set; }

        public User ApproverUser { get; set; }
        public Int64? ApproverId { get; set; } = null;

        public Status Status { get; set; }
        public Int64 StatusId { get; set; }
        public IEnumerable<Offer> Offers { get; set; }

    }
}
