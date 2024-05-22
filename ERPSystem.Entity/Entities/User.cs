using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string? Image { get; set; }
        public Department Department { get; set; }
        public Int64 DepartmentId { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
        public IEnumerable<Request> RequesterUsers { get; set; }
        public IEnumerable<Request> ApproverUsers { get; set; }
        public IEnumerable<Offer> ApproverOfferUsers { get; set; }
        public IEnumerable<StockDetail> RecieverStockDetails { get; set; }
        public IEnumerable<StockDetail> DelivererStockDetails { get; set; }
    }
}
