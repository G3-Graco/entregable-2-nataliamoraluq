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
        //[HttpGet] -> GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mision>>> Get()
        {
            var Misiones = await _servicio.GetAll();
            return Ok(Misiones);
        }

        //[HttpPost] -> CREATE
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

        //[HttpPut("{id}")] -> UPDATE
        [HttpPut("{id}")]
        public async Task<ActionResult<Mision>> Update(int id, string algo, [FromBody] Mision mision)
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

        //[HttpDelete("{id}")] -> DELETE
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