using AutoMapper;
using ERPSystem.Entity.DTO.CategoryDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.CategoryMapper
{
    public class CategoryResponseMapper:Profile
    {
        public CategoryResponseMapper()
        {
            CreateMap<Category,CategoryDTOResponse>();
            CreateMap<CategoryDTOResponse, Category>();
        }
    }
}
