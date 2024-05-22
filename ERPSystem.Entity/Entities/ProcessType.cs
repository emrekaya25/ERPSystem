using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class ProcessType:BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<StockDetail> StockDetails { get; set; }
    }
}
