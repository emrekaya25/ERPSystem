using ERPSystem.Entity.DTO.StockDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Abstract
{
    public interface IStockService:IGenericService<StockDTORequest, StockDTOResponse>
    {
    }
}
