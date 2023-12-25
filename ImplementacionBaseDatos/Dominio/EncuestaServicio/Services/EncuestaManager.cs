using EncuestasDAO.DAO;
using EncuestasModels.Models;
using EncuestasSQLServerDaoImpl.SQLServerdaoImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestaServicio.Models
{
    public class EncuestaManager
    {
        //inyección!
        IEncuestaDAO encuestaDAO { get; set; } = new EncuestaSQLServerDaoImpl();
          
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
    }
}
