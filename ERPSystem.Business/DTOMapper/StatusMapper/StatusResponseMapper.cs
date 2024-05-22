using AutoMapper;
using ERPSystem.Entity.DTO.StatusDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.StatusMapper
{
    public class StatusResponseMapper:Profile
    {
        public StatusResponseMapper()
        {
            CreateMap<Status,StatusDTOResponse>();
            CreateMap<StatusDTOResponse, Status>();
        }
    }
}
