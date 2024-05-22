using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class Company:BaseEntity
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
    }
}
