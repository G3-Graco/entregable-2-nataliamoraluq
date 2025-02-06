using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Entities;
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