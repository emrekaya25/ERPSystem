using AutoMapper;
using ERPSystem.Entity.DTO.UserRoleDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.UserRoleMapper
{
    public class UserRoleRequestMapper:Profile
    {
        public UserRoleRequestMapper()
        {
            CreateMap<UserRole,UserRoleDTORequest>();
            CreateMap<UserRoleDTORequest, UserRole>();
        }
    }
}
