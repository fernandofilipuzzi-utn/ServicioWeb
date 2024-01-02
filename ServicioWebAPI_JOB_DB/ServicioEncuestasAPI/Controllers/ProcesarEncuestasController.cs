using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioEncuestasAPI.Controllers
{
    public class ProcesarEncuestasController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetActualizarEncuestas()
        {
            EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();

            try
            {
                manager.ActualizarEstadisticasEnCurso();
            }
            catch (Exception ex)
            {

            }

            return Ok();
        }

        

    }
}
