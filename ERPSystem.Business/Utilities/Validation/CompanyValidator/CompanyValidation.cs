using ERPSystem.Entity.DTO.CompanyDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.CompanyValidator
{
    public class CompanyValidation:AbstractValidator<CompanyDTORequest>
    {
        public CompanyValidation()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Şirket ismi boş olamaz!");
            RuleFor(x => x.Name).MinimumLength(2).MaximumLength(75).WithMessage("Şirket ismi 2 karakterden küçük , 75 karakterden büyük olamaz!");
        }
    }
}
