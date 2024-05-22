using AutoMapper;
using ERPSystem.Entity.DTO.OfferDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.OfferMapper
{
    public class OfferResponseMapper:Profile
    {
        public OfferResponseMapper()
        {
            CreateMap<Offer, OfferDTOResponse>()
                .ForMember(dest => dest.ApproverUser, opt =>
            {
                opt.MapFrom(src => src.ApproverOfferUser.Name);
            })
                .ForMember(dest => dest.StatusName, opt =>
            {
                opt.MapFrom(src => src.Status.Name);
            }).
            ForMember(dest => dest.Name, opt =>
            {
                opt.MapFrom(src=>src.Request.Title);
            }).ReverseMap();
        }
    }
}
