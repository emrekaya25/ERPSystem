using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.StockDTO
{
    public class StockDTOResponse:BaseResponseDTO
    {
        public Int64 Id { get; set; }
        public Int64 ProductId { get; set; }
        public Int64 UnitId { get; set; }
        public decimal Quantity { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string UnitName { get; set; }
        public string DepartmentName { get; set; }
        public string ProductImage { get; set; }
    }
}
