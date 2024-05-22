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
    public class ProductResponseMapper:Profile
    {
        public ProductResponseMapper()
        {
            CreateMap<Product, ProductDTOResponse>().ForMember(dest => dest.CategoryName, opt =>
            {
                opt.MapFrom(src=>src.Category.Name);
            }).ReverseMap();
        }
    }
}
