using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Models.Validations
{
    public class ItemVendaValidation : AbstractValidator<ItemVenda>
    {
        public ItemVendaValidation()
        {
            RuleFor(i => i.Quantidade)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(i => i.Quantidade)
                .LessThanOrEqualTo(2).WithMessage("Quantidade indisponvivel em estoque.");
        }
    }
}
