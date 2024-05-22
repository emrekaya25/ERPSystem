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
    public class OfferRequestMapper:Profile
    {
        public OfferRequestMapper()
        {
            CreateMap<Offer,OfferDTORequest>();
            CreateMap<OfferDTORequest, Offer>();

        }
    }
}
