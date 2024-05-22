using ERPSystem.Entity.DTO.UserDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.UserValidator
{
    public class UserValidation:AbstractValidator<UserDTORequest>
    {
        public UserValidation()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Kullanıcı ismi boş olamaz!");
            RuleFor(x=>x.Name).MaximumLength(50).MinimumLength(2).WithMessage("İsim 2 karakterden küçük , 50 karakterden büyük olamaz!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Kullanıcı epostası boş olamaz!");
            RuleFor(x => x.Email).Matches("[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$").WithMessage("EPosta Formatı Doğru Değil!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Kullanıcı şifresi boş olamaz!");
            RuleFor(x=>x.Phone).NotEmpty().WithMessage("Kullanıcı telefon numarası boş olamaz!");
            RuleFor(x => x.Phone).MinimumLength(11).MaximumLength(11).WithMessage("Telefon numarası 11 karakterden büyük veya küçük olamaz!");
        }
    }
}
