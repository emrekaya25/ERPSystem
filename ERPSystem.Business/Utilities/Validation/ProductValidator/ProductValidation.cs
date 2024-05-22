using ERPSystem.Entity.DTO.ProductDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.ProductValidator
{
    public class ProductValidation:AbstractValidator<ProductDTORequest>
    {
        public ProductValidation()
        {
            RuleFor(x=>x.Name).MaximumLength(50).MinimumLength(2).WithMessage("Ürün ismi 2 karakterden küçük , 50 karakterden büyük olamaz!");
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ürün ismi boş olamaz!");
            RuleFor(x => x.BrandName).MaximumLength(60).MinimumLength(2).WithMessage("Ürün markası 2 karakterden küçük , 50 karakterden büyük olamaz!");
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Ürün markası boş olamaz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz!");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Açıklama 1000 karakterden büyük olamaz!");
        }
    }
}
