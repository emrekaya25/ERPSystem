using AutoMapper;
using ERPSystem.Entity.DTO.RequestDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.RequestMapper
{
    public class RequestResponseMapper:Profile
    {
        public RequestResponseMapper()
        {
            CreateMap<Request, RequestDTOResponse>()
                .ForMember(dest => dest.ProductName, opt =>
            {
                opt.MapFrom(src => src.Product.Name);
            })
                .ForMember(dest => dest.ApproverName, opt =>
                {
                    opt.MapFrom(src => src.ApproverUser.Name);
                }).
                ForMember(dest => dest.UnitName, opt =>
                {
                    opt.MapFrom(src => src.Unit.Name);
                }).
                ForMember(dest => dest.RequesterName, opt =>
                {
                    opt.MapFrom(src=>src.RequesterUser.Name);
                })
                .ForMember(dest => dest.StatusName, opt =>
                {
                    opt.MapFrom(src=>src.Status.Name);
                }).ReverseMap();
        }
    }
}
