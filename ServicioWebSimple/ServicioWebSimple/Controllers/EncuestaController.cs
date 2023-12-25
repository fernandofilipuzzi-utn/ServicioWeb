using EncuestasModels;
using EncuestasModels.Models;
using EncuestasModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioEncuestasSimple.Controllers
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
                
        public void GetIniciarEncuesta(int anio, string localidad)
        {
            manager.IniciarEncuesta(anio, localidad);
        }
        
        public void GetCerrarEncuesta(double distancia)
        {
            manager.CerrarEncuesta();
        }

        public void GetRegistrarEncuesta(string email, bool usaBicicleta, bool camina , bool usaTransportePublico, bool usaTransportePrivado, double distanciaRecorrida)
        {
            Respuesta nuevo = new Respuesta{ Email = email, 
                                              UsaBicicleta = usaBicicleta,
                                              Camina = camina,
                                              };
            //manager.RegistrarEncuesta(nuevo);
        }
    }
}
