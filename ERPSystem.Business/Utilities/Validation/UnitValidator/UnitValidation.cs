using ERPSystem.Entity.DTO.UnitDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.UnitValidator
{
    public class UnitValidation:AbstractValidator<UnitDTORequest>
    {
        public UnitValidation()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Birim ismi boş olamaz.");
        }
    }
}
