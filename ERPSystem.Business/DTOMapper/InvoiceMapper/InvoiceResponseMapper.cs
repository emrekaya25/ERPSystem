using AutoMapper;
using ERPSystem.Entity.DTO.InvoiceDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.InvoiceMapper
{
    public class InvoiceResponseMapper:Profile
    {
        public InvoiceResponseMapper()
        {
            CreateMap<Invoice,InvoiceDTOResponse>()
                .ForMember(dest=>dest.CompanyName , opt =>
            {
                opt.MapFrom(x => x.Company.Name);
            }).
            ForMember(dest=>dest.CompanyPhone , opt =>
            {
                opt.MapFrom(x=>x.Company.Phone);
            }).
            ForMember(dest=>dest.CompanyMail , opt =>
            {
                opt.MapFrom(src => src.Company.Mail);
            }).
            ForMember(dest => dest.InvoiceDetails, opt =>
            {
                opt.MapFrom(src => src.InvoiceDetails);//***
            }).ReverseMap();
        }
    }
}
