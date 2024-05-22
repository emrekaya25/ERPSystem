using ERPSystem.Entity.DTO.StockDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.StockValidator
{
    public class StockValidation:AbstractValidator<StockDTORequest>
    {
        public StockValidation()
        {
            RuleFor(x=>x.Quantity).NotEmpty().WithMessage("Stok miktar bilgisi boş olamaz!");
            RuleFor(x=>x.ProductId).NotEmpty().WithMessage("Stok ürün bilgisi boş olamaz!");
            RuleFor(x=>x.UnitId).NotEmpty().WithMessage("Stok birim bilgisi boş olamaz!");
        }
    }
}
