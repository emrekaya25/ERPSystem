using AutoMapper;
using ERPSystem.Entity.DTO.RequestDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.RequestMapper
{
    public class RequestRequestMapper:Profile
    {
        public RequestRequestMapper()
        {
            CreateMap<Request, RequestDTORequest>();
            CreateMap<RequestDTORequest, Request>();
        }
    }
}
