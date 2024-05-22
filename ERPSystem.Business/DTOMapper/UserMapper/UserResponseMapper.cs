using AutoMapper;
using ERPSystem.Entity.DTO.UserDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.UserMapper
{
    public class UserResponseMapper:Profile
    {
        public UserResponseMapper()
        {
            CreateMap<User, UserDTOResponse>().ForMember(dest => dest.DepartmentName, opt =>
            {
                opt.MapFrom(src=>src.Department.Name);
            }).
            ForMember(dest => dest.CompanyName, opt =>
            {
                opt.MapFrom(src=>src.Department.Company.Name);
            }).
            ForMember(dest => dest.Roles, opt =>
            {
                opt.MapFrom(src => src.UserRoles.Select(x=>x.Role));//*****
            }).
            ForMember(dest => dest.DepartmentId, opt =>
            {
                opt.MapFrom(src=>src.DepartmentId);
            }).ReverseMap();
        }
    }
}
