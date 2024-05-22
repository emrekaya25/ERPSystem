using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.RequestDTO
{
    public class RequestDTOResponse:BaseResponseDTO
    {
        public Int64 Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public Int64 ProductId { get; set; }
        public string ProductName { get; set; }
        public Int64 UnitId { get; set; }
        public string UnitName { get; set; }
        public Int64 RequesterId { get; set; }
        public string RequesterName { get; set; }
        public Int64? ApproverId { get; set; }
        public string ApproverName { get; set; }
        public Int64 StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
