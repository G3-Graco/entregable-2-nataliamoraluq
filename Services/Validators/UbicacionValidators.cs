using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class UbicacionValidators : AbstractValidator<Ubicacion>
    {
        public UbicacionValidators()
        {
            RuleFor(ubication => ubication.nombre)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(ubication => ubication.descripcion)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(ubication => ubication.clima)
                .NotEmpty()
                .MaximumLength(255);
        }
        
    }
}