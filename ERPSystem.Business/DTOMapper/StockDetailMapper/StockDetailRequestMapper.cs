using AutoMapper;
using ERPSystem.Entity.DTO.StockDetailDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.StockDetailMapper
{
    public class StockDetailRequestMapper:Profile
    {
        public StockDetailRequestMapper()
        {
            CreateMap<StockDetail,StockDetailDTORequest>();
            CreateMap<StockDetailDTORequest, StockDetail>();
        }
    }
}
