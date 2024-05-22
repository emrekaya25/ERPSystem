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
    public class InvoiceDetailResponseMapper:Profile
    {
        public InvoiceDetailResponseMapper()
        {
            CreateMap<InvoiceDetail, InvoiceDetailDTOResponse>();
            CreateMap<InvoiceDetailDTOResponse, InvoiceDetail>();
        }
    }
}
