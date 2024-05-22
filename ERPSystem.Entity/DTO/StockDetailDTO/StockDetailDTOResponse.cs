using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.StockDetailDTO
{
    public class StockDetailDTOResponse:BaseResponseDTO
    {
        public Int64 Id { get; set; }
        public decimal Quantity { get; set; }
        public Int64 StockId { get; set; }
        public Int64 ProcessTypeId { get; set; }
        public Int64 ReceiverId { get; set; }
        public Int64 DelivererId { get; set; }
        public string StockName { get; set; }
        public string ProcessTypeName { get; set; }
        public string RecieverName { get; set; }
        public string DelivererName { get; set; }
        public DateTime AddedTime { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string StockDetailImage { get; set; }
        public string StockDetailUnitName { get; set; }


    }
}
