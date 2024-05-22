using ERPSystem.Entity.DTO.DepartmentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Abstract
{
    public interface IDepartmentService:IGenericService<DepartmentDTORequest,DepartmentDTOResponse>
    {
    }
}
