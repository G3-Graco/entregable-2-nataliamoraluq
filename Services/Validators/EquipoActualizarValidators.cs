using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class EquipoActualizarValidators : AbstractValidator<Equipo>
    {
        public EquipoActualizarValidators(){
            RuleFor(x => x.casco)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(x => x.armadura)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(x => x.arma1)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(x => x.arma2)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(x => x.guanteletes)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(x => x.grebas)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}