using ERPSystem.Entity.DTO.StockDetailDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.StockDetailValidator
{
    public class StockDetailValidation:AbstractValidator<StockDetailDTORequest>
    {
        public StockDetailValidation()
        {
            RuleFor(x=>x.ProcessTypeId).NotEmpty().WithMessage("Stok detayı işlem tipi boş olamaz!");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Miktar boş olamaz!");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Miktar boş olamaz!");
            RuleFor(x => x.StockId).NotEmpty().WithMessage("Stok detayı stok bilgisi boş olamaz!");
        }
    }
}
