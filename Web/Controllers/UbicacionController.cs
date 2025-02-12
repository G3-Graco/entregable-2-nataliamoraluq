using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Entities;
using Core.Services;
using Services.Services;
using Core.Interfaces.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionController : ControllerBase
    {
        private IUbicacionService _servicio;
        public UbicacionController(IUbicacionService ubicacionService){
            _servicio = ubicacionService;
        }

        // --- HTTP REQUEST: ---
        //[HttpGet] -> GET ALL
        /// <summary>
        /// Obtener todas las ubicaciones
        /// </summary>
        /// <returns>Lista de Ubicaciones</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> Get()
        {
            var Ubicaciones = await _servicio.GetAll();
            return Ok(Ubicaciones);
        }

        //[HttpPost] -> CREATE

        /// <summary>
        /// Crear ubicacion
        /// </summary>
        /// <param name="ubicacion"></param>
        /// <returns>Ubicacion creada</returns>
        [HttpPost]
        public async Task<ActionResult<Ubicacion>> Post([FromBody] Ubicacion ubicacion)
        {
            try
            {
                var createdUbicacion =
                    await _servicio.Create(ubicacion);
                return Ok(createdUbicacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpDelete("{id}")] -> DELETE

        /// <summary>
        /// Eliminar ubicacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ubicacion eliminada</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> Delete(int id)
        {
            try
            {
                await _servicio.Delete(id);
                return Ok("Ubicacion eliminada! :D ");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPut("{id}")] -> UPDATE

        /// <summary>
        /// Actualziar info de una ubicacion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="algo"></param>
        /// <param name="ubicacion"></param>
        /// <returns>Ubicacion actualizada con la nueva data</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Ubicacion>> Update(int id, string algo, [FromBody] Ubicacion ubicacion)
        {
            try
            {
                await _servicio.Update(id, ubicacion);
                return Ok("Ubicacion Actualizada!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPost("Mover")] -> MOVER UBICACION -> * MET ESPECIFICO
    }
}