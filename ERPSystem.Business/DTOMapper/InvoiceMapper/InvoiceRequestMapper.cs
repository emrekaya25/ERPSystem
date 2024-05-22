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
    public class InvoiceRequestMapper:Profile
    {
        public InvoiceRequestMapper()
        {
            CreateMap<InvoiceDTORequest, Invoice>().ForMember(dest => dest.InvoiceDetails, opt =>
            {
                opt.MapFrom(src => src.InvoiceDetails);
            });

        }
    }
}
