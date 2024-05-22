using ERPSystem.Entity.DTO.DepartmentDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.DepartmentValidator
{
    public class DepartmentValidation:AbstractValidator<DepartmentDTORequest>
    {
        public DepartmentValidation()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Departman ismi boş olamaz!");
            RuleFor(x => x.Name).MaximumLength(75).MinimumLength(3).WithMessage("Departman ismi 3 karakterden az , 75 karakterden fazla olamaz !");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Şirket ismi boş olamaz!");
        }
    }
}
