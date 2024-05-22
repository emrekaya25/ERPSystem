using ERPSystem.Entity.DTO.CompanyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Abstract
{
    public interface ICompanyService:IGenericService<CompanyDTORequest, CompanyDTOResponse>
    {
    }
}
