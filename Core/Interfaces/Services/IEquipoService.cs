using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Services;
using Core.Responses;

namespace Core.Interfaces.Services
{
    public interface IEquipoService : IBaseService<Equipo>
    {
        /*Task<Mision> Equipar(int personajeId, int objetoToAddId);
        Task<Mision> Desequipar(int personajeId, int objetoToRemoveId);
        */
    }
}