using AutoMapper;
using ERPSystem.Entity.DTO.CompanyDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.CompanyMapper
{
    public class CompanyResponseMapper:Profile
    {
        public CompanyResponseMapper()
        {
            CreateMap<Company,CompanyDTOResponse>();
            CreateMap<CompanyDTOResponse, Company>();
        }
    }
}
