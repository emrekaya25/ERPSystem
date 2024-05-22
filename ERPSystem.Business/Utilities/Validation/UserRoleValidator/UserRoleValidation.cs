using ERPSystem.Entity.DTO.UserRoleDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.UserRoleValidator
{
    public class UserRoleValidation:AbstractValidator<UserRoleDTORequest>
    {
        public UserRoleValidation()
        {
            RuleFor(x=>x.UserId).NotEmpty().WithMessage("Kullanıcı/Rol için kullanıcı bilgisi boş olamaz!");
            RuleFor(x=>x.RoleId).NotEmpty().WithMessage("Kullanıcı/Rol için rol bilgisi boş olamaz!");
        }
    }
}
