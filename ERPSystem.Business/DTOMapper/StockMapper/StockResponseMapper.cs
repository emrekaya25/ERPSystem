using AutoMapper;
using ERPSystem.Entity.DTO.StockDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.StockMapper
{
    public class StockResponseMapper:Profile
    {
        public StockResponseMapper()
        {
            CreateMap<Stock, StockDTOResponse>().ForMember(dest => dest.ProductName, opt =>
            {
                opt.MapFrom(src=>src.Product.Name);
            }).
            ForMember(dest => dest.UnitName, opt =>
            {
                opt.MapFrom(src=>src.Unit.Name);
            }).
            ForMember(dest => dest.DepartmentName, opt =>
            {
                opt.MapFrom(src=>src.Department.Name);
            }).
            ForMember(dest => dest.ProductImage, opt =>
            {
                opt.MapFrom(src=>src.Product.Image);
            }).
            ForMember(dest => dest.CompanyName, opt =>
            {
                opt.MapFrom(src=>src.Department.Company.Name);
            }).ReverseMap();
        }
    }
}
