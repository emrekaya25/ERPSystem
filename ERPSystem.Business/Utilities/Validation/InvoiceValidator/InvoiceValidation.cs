using ERPSystem.Entity.DTO.InvoiceDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.InvoiceValidator
{
    public class InvoiceValidation:AbstractValidator<InvoiceDTORequest>
    {
        public InvoiceValidation()
        {
            RuleFor(x => x.SupplierName).NotEmpty().WithMessage("Satıcı ismi boş olamaz!");
            RuleFor(x => x.SupplierName).MinimumLength(3).MaximumLength(50).WithMessage("Satıcı ismi 3 karakterden küçük , 50 karakterden büyük olamaz!");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Şirket ismi boş olamaz!");
            RuleFor(x => x.CompanyName).MinimumLength(3).MaximumLength(50).WithMessage("Şirket ismi 3 karakterden küçük , 50 karakterden büyük olamaz!");

        }
    }
}
