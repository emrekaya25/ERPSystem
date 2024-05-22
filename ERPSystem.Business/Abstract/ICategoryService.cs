using ERPSystem.Entity.DTO.CategoryDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Abstract
{
    public interface ICategoryService:IGenericService<CategoryDTORequest,CategoryDTOResponse>
    {
    }
}
