using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public Company Company { get; set; }
        public Int64 CompanyId { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }
    }
}
