using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class Stock:BaseEntity
    {
        public decimal Quantity { get; set; }
        public Product Product { get; set; }
        public Int64 ProductId { get; set; }
        public Unit Unit { get; set; }
        public Int64 UnitId { get; set; }
        public Department Department { get; set; }
        public Int64 DepartmentId { get; set; }

        public IEnumerable<StockDetail> StockDetails { get; set; }
    }
}
