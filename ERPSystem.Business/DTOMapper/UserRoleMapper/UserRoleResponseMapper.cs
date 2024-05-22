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
    public class UserRoleResponseMapper:Profile
    {
        public UserRoleResponseMapper()
        {
            CreateMap<UserRole, UserRoleDTOResponse>().ForMember(dest => dest.UserName, opt =>
            {
                opt.MapFrom(src => src.User.Name);
            }).ForMember(dest => dest.RoleName, opt =>
            {
                opt.MapFrom(src => src.Role.Name);
            }).ReverseMap() ;
        }
    }
}
