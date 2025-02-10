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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> Get()
        {
            var Ubicaciones = await _servicio.GetAll();
            return Ok(Ubicaciones);
        }

        //[HttpPost] -> CREATE
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