using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Business.Models.Validations
{
    public class DepartamentoValidation : AbstractValidator<Departamento>
    {
        public DepartamentoValidation()
        {
            RuleFor(d => d.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 100).WithMessage("O campo tata {PropertyName} precisa ter entre {MinLength} e {MaxLength}");
        }
    }
}
