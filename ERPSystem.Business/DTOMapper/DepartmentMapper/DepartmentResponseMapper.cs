using AutoMapper;
using ERPSystem.Entity.DTO.DepartmentDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.DepartmentMapper
{
    public class DepartmentResponseMapper : Profile
    {
        public DepartmentResponseMapper()
        {
            CreateMap<Department, DepartmentDTOResponse>().ForMember(dest => dest.CompanyName, opt =>
            {
                opt.MapFrom(src => src.Company.Name);
            })
            .ForMember(dest => dest.CompanyId, opt =>
            {
                opt.MapFrom(x => x.Company.Id);
            }).ReverseMap();

                
        }
    }
}
