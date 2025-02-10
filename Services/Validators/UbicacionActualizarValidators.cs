using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class UbicacionActualizarValidators : AbstractValidator<Ubicacion>
    {
        public UbicacionActualizarValidators(){
            RuleFor(ubic => ubic.nombre)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(ubic => ubic.descripcion)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(ubic => ubic.clima)
                .NotEmpty()
                .MaximumLength(255);
        }
        
    }
}