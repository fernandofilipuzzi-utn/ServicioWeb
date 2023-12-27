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

        public Encuesta EncuestaEnCurso 
        {
            get {
                return encuestaDAO.BuscarUltimaEncuestaNoCerrada();
            }
        }

        public void IniciarEncuesta(int anio, string localidad)
        {
            Encuesta nueva = new Encuesta { Anio=anio, Localidad=localidad};
            encuestaDAO.Agregar(nueva);
        }

        public void CerrarEncuesta()
        {
            if (EncuestaEnCurso != null)
            {
                EncuestaEnCurso.ActualizarEstadistica();
                encuestaDAO.Actualizar(EncuestaEnCurso);
            }
        }

        public void RegistrarRespuesta(Respuesta nuevo)
        {
            respuestaDAO.Agregar(nuevo, EncuestaEnCurso);
            EncuestaEnCurso.RegistrarRespuesta(nuevo);
        }
    }
}
