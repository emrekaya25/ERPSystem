using AutoMapper;
using ERPSystem.Entity.DTO.RoleDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.RoleMapper
{
    public class RoleResponseMapper:Profile
    {
        public RoleResponseMapper()
        {
            CreateMap<Role,RoleDTOResponse>();
            CreateMap<RoleDTOResponse, Role>();
        }
    }
}
