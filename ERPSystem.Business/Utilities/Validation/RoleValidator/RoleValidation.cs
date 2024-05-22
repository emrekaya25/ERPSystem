using ERPSystem.Entity.DTO.RoleDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.RoleValidator
{
    public class RoleValidation:AbstractValidator<RoleDTORequest>
    {
        public RoleValidation()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Rol ismi boş olamaz!");
            RuleFor(x => x.Name).MinimumLength(2).MaximumLength(50).WithMessage("Rol ismi 2 karakterden küçük, 50 karakterden büyük olamaz!");
        }
    }
}
