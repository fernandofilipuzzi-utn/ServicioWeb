using EncuestasDAO.DAO;
using EncuestasModels.Models;
using EncuestasSQLServerDaoImpl.SQLServerdaoImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestaServicio.Services
{
    public class EncuestaManager
    {
        //inyección!
        IEncuestaDAO encuestaDAO { get; set; } = new EncuestaSQLServerDaoImpl();
        IRespuestaDAO respuestaDAO { get; set; } = new RespuestaSQLServerDaoImpl();

        public List<Encuesta> EncuestasEnCurso 
        {
            get {
                return encuestaDAO.BuscarUltimasEncuestaNoCerradas();
            }
        }

        public void IniciarEncuesta(int anio, string localidad)
        {
            Encuesta nueva = new Encuesta { Anio=anio, Localidad=localidad, EnCurso=true};
            encuestaDAO.Agregar(nueva);
        }

        public void CerrarEncuesta()
        {
            /*ajustes de modelo hay que arreglar -> podría ser que el cierre se haga en todas las abiertas
            if (EncuestaEnCurso != null)
            {
                EncuestaEnCurso.ActualizarEstadistica();
                encuestaDAO.Actualizar(EncuestaEnCurso);
            }
            */
        }

        public void RegistrarRespuesta(Respuesta nuevo, Encuesta aDonde)
        {
            respuestaDAO.Agregar(nuevo, aDonde);
        }
    }
}
