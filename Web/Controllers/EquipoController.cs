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

        //[HttpPost] -> CREATE
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

        //[HttpPut("{id}")] -> UPDATE
        [HttpPut("{id}")]
        public async Task<ActionResult<Equipo>> Update(int id, string algo, [FromBody] Equipo equipo)
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

        //[HttpDelete("{id}")] -> DELETE
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