using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class Status:BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<Offer> Offers { get; set; }
    }
}
