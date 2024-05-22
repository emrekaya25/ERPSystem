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
    public class StatusRequestMapper:Profile
    {
        public StatusRequestMapper()
        {
            CreateMap<Status,StatusDTORequest>();
            CreateMap<StatusDTORequest, Status>();
        }
    }
}
