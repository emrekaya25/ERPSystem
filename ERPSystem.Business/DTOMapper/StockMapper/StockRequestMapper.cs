using AutoMapper;
using ERPSystem.Entity.DTO.StockDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.StockMapper
{
    public class StockRequestMapper:Profile
    {
        public StockRequestMapper()
        {
            CreateMap<Stock,StockDTORequest>();
            CreateMap<StockDTORequest, Stock>();
        }
    }
}
