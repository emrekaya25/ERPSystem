using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Base
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }
        public DateTime AddedTime { get; set; }
        public bool IsActive { get; set; }
    }
}
