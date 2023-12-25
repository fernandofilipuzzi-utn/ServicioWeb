using EncuestasModels;
using EncuestasModels.Models;
using EncuestasModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioWebSimpleCss.Controllers
{
    internal class EncuestaController
    {
        //debemos valerno de algo como un singleton porque no se mantiene el estado de este objeto
        //si reinstanciamos cada vez que llamamos al controlador perdemos el estado
        private EncuestaManager manager{
            get 
            {
                return EncuestaManagerSingleton.Instancia;
            } 
        }
                
        public Encuesta GetIniciarEncuesta(int anio, string localidad)
        {
            manager.IniciarEncuesta(anio, localidad);
            return manager.EncuestaEnCurso;
        }
        
        public Encuesta GetCerrarEncuesta()
        {
            Encuesta enCierre= manager.EncuestaEnCurso;
            manager.CerrarEncuesta();
            return enCierre;
        }

        public void GetRegistrarEncuesta(string email, bool usaBicicleta, bool camina , bool usaTransportePublico, bool usaTransportePrivado, double distanciaRecorrida)
        {
            Respuesta nuevo = new Respuesta{ Email = email, 
                                              UsaBicicleta = usaBicicleta,
                                              Camina = camina,
                                              };
            manager.EncuestaEnCurso.RegistrarRespuesta(nuevo);
        }
    }
}
