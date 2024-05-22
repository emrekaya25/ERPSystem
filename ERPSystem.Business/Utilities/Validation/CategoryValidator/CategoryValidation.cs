using ERPSystem.Entity.DTO.CategoryDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.CategoryValidator
{
    public class CategoryValidation:AbstractValidator<CategoryDTORequest>
    {
        public CategoryValidation()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Kategori ismi boş olamaz.");
            RuleFor(x=>x.Name).MinimumLength(2).WithMessage("Kategori ismi 2 karakterden küçük ");
            RuleFor(x=>x.Name).MaximumLength(50).WithMessage("Kategori ismi 50 karakterden büyük olamaz!");
        }
    }
}
