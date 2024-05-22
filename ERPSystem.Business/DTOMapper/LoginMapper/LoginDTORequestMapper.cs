using AutoMapper;
using ERPSystem.Entity.DTO.LoginDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.LoginMapper
{
    public class LoginDTORequestMapper:Profile
    {
        public LoginDTORequestMapper()
        {
            CreateMap<User, LoginDTORequest>().ForMember(dest => dest.Email, opt =>
            {
                opt.MapFrom(src => src.Email);
            }).
            ForMember(dest => dest.Password, opt =>
            {
                opt.MapFrom(src => src.Password);
            }).ReverseMap();
        }
    }
}
