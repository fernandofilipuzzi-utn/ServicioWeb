using EncuestasClassLib;
using EncuestasClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServicio.Controllers
{
    internal class WebRegistroDeEncuestaController
    {
        static ProcesoEncuestas gestor = new ProcesoEncuestas();

        public void GetRegistrarEncuesta(double distancia)
        {
            Encuesta nueva = new Encuesta();
            gestor.RegistrarEncuesta(nueva, false);
        }
    }
}
