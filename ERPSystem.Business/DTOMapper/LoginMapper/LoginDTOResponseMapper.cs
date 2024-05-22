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
    public class LoginDTOResponseMapper:Profile
    {
        public LoginDTOResponseMapper()
        {
            CreateMap<User, LoginDTOResponse>().
                ForMember(dest => dest.Name, opt =>
                {
                    opt.MapFrom(src => src.Name);
                }).
                ForMember(dest => dest.CompanyName, opt =>
                {
                    opt.MapFrom(src => src.Department.Company.Name);
                }).
                ForMember(dest => dest.DepartmentName, opt =>
                {
                    opt.MapFrom(src => src.Department.Name);
                }).
                ForMember(dest => dest.Email, opt =>
                {
                    opt.MapFrom(src => src.Email);
                }).
                ForMember(dest => dest.DepartmentId, opt =>
                {
                    opt.MapFrom(src => src.DepartmentId);
                }).
                ForMember(dest => dest.CompanyId, opt =>
                {
                    opt.MapFrom(src => src.Department.CompanyId);
                }).
                ForMember(dest => dest.Password, opt =>
                {
                    opt.MapFrom(src => src.Password);
                }).
                ForMember(dest => dest.UserId, opt =>
                {
                    opt.MapFrom(src=>src.Id);
                }).
                ForMember(dest => dest.RoleName, opt =>
                {
                    opt.MapFrom(src => src.UserRoles.Select(x => x.Role.Name).ToList());//*****
                }).
                ForMember(dest => dest.UserImage, opt =>
                {
                    opt.MapFrom(src=>src.Image);
                }).ReverseMap();
        }
    }
}
