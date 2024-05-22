using ERPSystem.Entity.DTO.RequestDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.RequestValidator
{
    public class RequestValidation:AbstractValidator<RequestDTORequest>
    {
        public RequestValidation()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("İstek başlığı boş olamaz!");
            RuleFor(x=>x.Title).MinimumLength(3).MaximumLength(60).WithMessage("İstek başlığı 2 karakterden küçük , 60 karakterden büyük olamaz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("İstek açıklaması boş olamaz!"); ;
            RuleFor(x => x.Description).MinimumLength(3).MaximumLength(1000).WithMessage("İstek açıklaması 3 karakterden küçük, 1000 karakterden büyük olamaz!");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("İstek miktar bilgisi girilmelidir!");
        }
    }
}
