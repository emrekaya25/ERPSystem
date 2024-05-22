using ERPSystem.Entity.DTO.StatusDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.StatusValidator
{
    public class StatusValidation:AbstractValidator<StatusDTORequest>
    {
        public StatusValidation()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Durum ismi boş olamaz");
            RuleFor(x=>x.Name).MinimumLength(3).MaximumLength(50).WithMessage("Durum ismi 3 karakterden küçük, 50 karakterden büyük olamaz");
        }
    }
}
