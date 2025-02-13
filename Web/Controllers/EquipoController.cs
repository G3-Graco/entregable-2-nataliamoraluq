using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipoController : ControllerBase
    {
        private IEquipoService _servicio;
        public EquipoController(IEquipoService equipoService){
            _servicio = equipoService;
        }

        // --- HTTP REQUEST: ---
        //[HttpGet] -> GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> Get()
        {
            var Equipos = await _servicio.GetAll();
            return Ok(Equipos);
        }

        //---------------------------------------------------------------------
        //[HttpPost] -> POST / create api <EquipoController>
        /// <summary>
        /// Crear un equipo
        /// </summary>
        /// <param name="equipo">Instancia de entidad equipo</param>
        /// <returns> equipo creado</returns>
        /// /// <remarks>
        /// Ejemplo de un JSON request 
        /// {
        ///        "id": 1,
        ///        "casco": "hx",
        ///        "armadura": "armaduraOro",
        ///        "arma1": "armaHielo1",
        ///        "arma2": "armaFuego2",
        ///        "guanteletes": "guantesGeneric2",
        ///        "grebas": "grebas4"        
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Equipo>> Post([FromBody] Equipo equipo)
        {
            try
            {
                var createdEquipo =
                    await _servicio.Create(equipo);
                return Ok(createdEquipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //---------------------------------------------------------------------
        //[HttpPut("{id}")] -> PUT / update api <EquipoController>
        /// <summary>
        /// Actualizar data/info. de un equipo
        /// </summary>
        /// <param name="id">ID del equipo </param>
        /// <param name="equipo">Instancia de entidad equipo</param>
        /// <returns> equipo actualizado con la nueva data</returns>
        /// <remarks>
        /// Ejemplo de un JSON request 
        /// {
        ///        "id": 1,
        ///        "casco": "helmet31",
        ///        "armadura": "armaduraBronce4",
        ///        "arma1": "armaHielo2",
        ///        "arma2": "armaFuego23",
        ///        "guanteletes": "xtremeGuant63",
        ///        "grebas": "grebas56"        
        /// }
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<ActionResult<Equipo>> Update(int id, [FromBody] Equipo equipo)
        {
            try
            {
                await _servicio.Update(id, equipo);
                return Ok("equipo actualizado correctamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // --------------------------------------------------------------------
        //[HttpDelete("{id}")] -> DELETE / delete api <EquipoController>
        /// <summary>
        /// Eliminar un equipo
        /// </summary>
        /// <param name="id"> ID del equipo a eliminar </param>
        /// <returns>Equipo eliminado</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Equipo>>> Delete(int id)
        {
            try
            {
                await _servicio.Delete(id);
                return Ok("Equipo eliminado!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut("Equipar")] -> Aceptar mision-> * MET ESPECIFICO
        //[HttpPut("Desequipar")] -> Indicar progreso -> * MET ESPECIFICO
    }
}