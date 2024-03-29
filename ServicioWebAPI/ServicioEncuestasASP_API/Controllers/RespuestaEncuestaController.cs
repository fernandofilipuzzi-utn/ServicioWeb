using EncuestasDAO.DAO;
using EncuestasNuevoModels.Models;
using EncuestasSQLServerDaoImpl.SQLServerDaoImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioEncuestas.Controllers
{
    public class RespuestaEncuestaController : ApiController
    {
       
        public IHttpActionResult Post(int idEncuesta, [FromBody] Respuesta nueva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();
                IEncuestaDAO encuestaDAO = new EncuestaSQLServerDaoImpl();
                Encuesta selectedEncuesta = encuestaDAO.BuscarPorId(idEncuesta);
                manager.RegistrarRespuesta(nueva, selectedEncuesta);
            }
            catch (Exception ex)
            {
                //throw new Exception("Error al agregar el registro", ex);

                InternalServerError(ex);
            }
            return Ok(nueva);
        }
    }
}
