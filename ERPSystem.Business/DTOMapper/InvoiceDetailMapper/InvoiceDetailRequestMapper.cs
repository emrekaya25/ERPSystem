using AutoMapper;
using ERPSystem.Entity.DTO.InvoiceDetailDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.InvoiceDetailMapper
{
    public class InvoiceDetailRequestMapper:Profile
    {
        public InvoiceDetailRequestMapper()
        {
            CreateMap<InvoiceDetail, InvoiceDetailDTORequest>();
            CreateMap<InvoiceDetailDTORequest, InvoiceDetail>();
        }
    }
}
