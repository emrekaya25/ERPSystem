using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
