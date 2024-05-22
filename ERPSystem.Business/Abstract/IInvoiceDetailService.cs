using ERPSystem.Entity.DTO.InvoiceDetailDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Abstract
{
    public interface IInvoiceDetailService:IGenericService<InvoiceDetailDTORequest,InvoiceDetailDTOResponse>
    {
    }
}
