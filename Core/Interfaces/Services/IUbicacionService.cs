using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IUbicacionService : IBaseService<Ubicacion>
    {
        //Task<Ubicacion> MoverUbicacion(int personajeRelated);
        //para cambiar la ubicacion actual del personaje a una nueva ubicacion
    }
}