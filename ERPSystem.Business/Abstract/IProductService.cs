using ERPSystem.Entity.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Abstract
{
    public interface IProductService:IGenericService<ProductDTORequest, ProductDTOResponse>
    {
    }
}
