using AutoMapper;
using ERPSystem.Entity.DTO.ProcessTypeDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.ProcessTypeMapper
{
    public class ProcessTypeResponseMapper:Profile
    {
        public ProcessTypeResponseMapper()
        {
            CreateMap<ProcessType,ProcessTypeDTOResponse>();
            CreateMap<ProcessTypeDTOResponse, ProcessType>();
        }
    }
}
