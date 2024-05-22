using AutoMapper;
using ERPSystem.Entity.DTO.UnitDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.UnitMapper
{
    public class UnitResponseMapper:Profile
    {
        public UnitResponseMapper()
        {
            CreateMap<Unit,UnitDTOResponse>();
            CreateMap<UnitDTOResponse, Unit>();
        }
    }
}
