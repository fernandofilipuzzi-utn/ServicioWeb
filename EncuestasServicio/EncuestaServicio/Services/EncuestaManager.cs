using EncuestasDAO.DAO;
using EncuestasSQLServerDaoImpl.SQLServerdaoImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasModels.Models
{
    public class EncuestaManager
    {
        IEncuestaDAO dao = new EncuestaSQLServerDaoImpl();
                
        public void IniciarEncuesta(int anio, string localidad)
        {
            Encuesta nueva = new Encuesta { Anio=anio, Localidad=localidad};
            dao.Agregar(nueva);
        }

        public void CerrarEncuesta()
        {
            
        }
    }
}
