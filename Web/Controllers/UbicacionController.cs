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

        // --------------------------------------------------------------------
        //[HttpGet] -> GET / Get all api <UbicacionController>
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

        // --------------------------------------------------------------------\
        //[HttpPost] -> POST / create api <UbicacionController>
        /// <summary>
        /// Crear ubicacion
        /// </summary>
        /// <param name="ubicacion">instancia de Ubicacion</param>
        /// <returns>Ubicacion creada</returns>
        /// /// <remarks>
        /// Ejemplo de un JSON request 
        /// {
        ///     "id": 0,
        ///     "nombre": "UBI-MAIN-N1-TUN",
        ///     "descripcion": "ubicacion principal del mapa X1Y",
        ///     "clima": "tundra"
        /// }
        /// </remarks>
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

        // --------------------------------------------------------------------
        //[HttpDelete("{id}")] -> DELETE / delete api <UbicacionController>
        /// <summary>
        /// Eliminar ubicacion
        /// </summary>
        /// <param name="id"> ID de la ubicacion a eliminar </param>
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


        // --------------------------------------------------------------------
        //[HttpPut("{id}")] -> PUT / update api <UbicacionController>
        /// <summary>
        /// Actualizar data/info. de una ubicacion
        /// </summary>
        /// <param name="id">ID de la ubicacion a actualizar</param>
        /// <param name="ubicacion">Instancia de entidad ubicacion</param>
        /// <returns>ubicacion actualizada con la nueva data</returns>
        /// <remarks>
        /// Ejemplo de un JSON request 
        /// {
        ///     "id": 0,
        ///     "nombre": "UBI-LOCT-MAIN-N1-TUN",
        ///     "descripcion": "ubicacion principal del mapa X1Y",
        ///     "clima": "tundra"
        /// }
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<ActionResult<Ubicacion>> Update(int id, [FromBody] Ubicacion ubicacion)
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