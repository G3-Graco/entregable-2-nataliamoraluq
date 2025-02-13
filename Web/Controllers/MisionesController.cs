using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Entities;
using Core.Interfaces.Services;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MisionesController : ControllerBase
    {
        private IMisionService _servicio;
        public MisionesController(IMisionService misionService){
            _servicio = misionService;
        }

        // --- HTTP REQUEST: ---
        
        // --------------------------------------------------------------------
        //[HttpGet] -> GET / Get all api <MisionController>
        /// <summary>
        /// Obtener todas las misiones registradas
        /// </summary>
        /// <returns>Lista de Misiones</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mision>>> Get()
        {
            var Misiones = await _servicio.GetAll();
            return Ok(Misiones);
        }

        //---------------------------------------------------------------------
        //[HttpPost] -> POST / create api <MisionController>
        /// <summary>
        /// Crear mision
        /// </summary>
        /// <param name="mision">Instancia de entidad mision</param>
        /// <returns> mision creada</returns>
        /// <remarks>
        /// Ejemplo de un JSON request 
        /// {
        ///        "id": 2,
        ///        "nombre": "mision - catch this pet!-",
        ///        "estado": "E"  
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Mision>> Post([FromBody] Mision mision)
        {
            try
            {
                var createdMision =
                    await _servicio.Create(mision);
                return Ok(createdMision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //---------------------------------------------------------------------
        //[HttpPut("{id}")] -> PUT / update api <MisionController>
        /// <summary>
        /// Actualizar data/info. de una mision
        /// </summary>
        /// <param name="id">ID de la mision a actualizar</param>
        /// <param name="mision">Instancia de entidad mision</param>
        /// <returns> mision actualizada con la nueva data</returns>
        /// <remarks>
        /// Ejemplo de un JSON request 
        /// {
        ///        "id": 2,
        ///        "nombre": "mision - catch this adventurepet!-",
        ///        "estado": "P"  
        /// }
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<ActionResult<Mision>> Update(int id, [FromBody] Mision mision)
        {
            try
            {
                await _servicio.Update(id, mision);
                return Ok("mision Actualizada!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // --------------------------------------------------------------------
        //[HttpDelete("{id}")] -> DELETE / delete api <MisionController>
        /// <summary>
        /// Eliminar mision
        /// </summary>
        /// <param name="id"> ID de la mision a eliminar </param>
        /// <returns>Mision eliminada</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Mision>>> Delete(int id)
        {
            try
            {
                await _servicio.Delete(id);
                return Ok("Mision eliminada! :D ");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //--------------------------------------------------------------------------

        //[HttpPost("Aceptar")] -> Aceptar mision-> * MET ESPECIFICO
        //[HttpPost("IndicarProg")] -> Indicar progreso -> * MET ESPECIFICO
        //[HttpPost("CompletarM")] -> Completar mision -> * MET ESPECIFICO
        

        //------------------------------------------------------------------------------
        //examen 1 - natalia ml - Web > Controllers> MisionesController.cs
        /*private IMisionesService _servicio;
        public MisionesController(IMisionesService misionesService) 
        {
            _servicio = misionesService;
        }

        [HttpPost("TerminarMision")]
        public async Task<ActionResult<Misiones>> TerminarMision(int idMision, int idPersonaje)
        {
            try
            {
                var currentMision =
                    await _servicio.Atacar(idMision, idPersonaje);

                return Ok(currentMision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

    }
}