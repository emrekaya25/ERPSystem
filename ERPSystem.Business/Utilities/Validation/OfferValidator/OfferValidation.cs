using ERPSystem.Entity.DTO.OfferDTO;
using ERPSystem.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.OfferValidator
{
    public class OfferValidation:AbstractValidator<OfferDTORequest>
    {
        public OfferValidation()
        {
            RuleFor(x=>x.SupplierName).NotEmpty().WithMessage("Satıcı ismi boş olamaz!");
            RuleFor(x=>x.SupplierName).MinimumLength(3).MaximumLength(50).WithMessage("Satıcı ismi 3 karakterden küçük , 50 karakterden büyük olamaz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz!");
            RuleFor(x => x.Description).MinimumLength(3).MaximumLength(1000).WithMessage("Açıklama 3 karakterden küçük , 1000 karakterden büyük olamaz!");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Lütfen geçerli bir fiyat giriniz!");

        }
    }
}
