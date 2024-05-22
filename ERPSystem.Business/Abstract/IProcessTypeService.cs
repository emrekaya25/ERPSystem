using ERPSystem.Entity.DTO.ProcessTypeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Abstract
{
    public interface IProcessTypeService:IGenericService<ProcessTypeDTORequest, ProcessTypeDTOResponse>
    {
    }
}
