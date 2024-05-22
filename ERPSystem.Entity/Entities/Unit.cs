using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class Unit:BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }
    }
}
