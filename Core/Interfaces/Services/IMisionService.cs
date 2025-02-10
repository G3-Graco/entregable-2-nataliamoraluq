using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Services;
using Core.Responses;

namespace Core.Interfaces.Services
{
    public interface IMisionService : IBaseService<Mision>
    {
        /*Task<Mision> Aceptar(int personajeToAcceptId);
        Task<Mision> IndicarProgreso(int personajeRelatedId);
        Task<Mision> Completar(int personajeRelatedId, List<string> recompensasToWin);*/
    }
}