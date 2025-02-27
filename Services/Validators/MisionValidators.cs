using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class MisionValidators : AbstractValidator<Mision>
    {
        public MisionValidators()
        {
            RuleFor(x => x.nombre)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(x => x.objetivos)
                .NotEmpty();
            RuleFor(x => x.recompensas)
                .NotEmpty();
            RuleFor(x => x.estado)
                .NotEmpty();
        }
        
    }
}