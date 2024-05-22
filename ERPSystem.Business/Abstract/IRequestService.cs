using ERPSystem.Entity.DTO.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Abstract
{
    public interface IRequestService:IGenericService<RequestDTORequest,RequestDTOResponse>
    {
    }
}
