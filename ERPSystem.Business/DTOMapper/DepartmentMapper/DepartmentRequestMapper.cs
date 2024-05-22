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
    public class DepartmentRequestMapper:Profile
    {
        public DepartmentRequestMapper()
        {
            CreateMap<Department,DepartmentDTORequest>();
            CreateMap<DepartmentDTORequest, Department>();
        }
    }
}
