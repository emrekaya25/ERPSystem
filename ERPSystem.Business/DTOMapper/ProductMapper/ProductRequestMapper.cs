using AutoMapper;
using ERPSystem.Entity.DTO.ProductDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.ProductMapper
{
    public class ProductRequestMapper:Profile
    {
        public ProductRequestMapper()
        {
            CreateMap<Product,ProductDTORequest>();
            CreateMap<ProductDTORequest, Product>();
        }
    }
}
