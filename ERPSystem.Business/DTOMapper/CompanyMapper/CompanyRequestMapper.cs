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
    public class CompanyRequestMapper:Profile
    {
        public CompanyRequestMapper()
        {
            CreateMap<Company,CompanyDTORequest>();
            CreateMap<CompanyDTORequest, Company>();
        }
    }
}
