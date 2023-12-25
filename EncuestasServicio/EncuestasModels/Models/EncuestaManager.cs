using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasModels.Models
{
    public class EncuestaManager
    {
        List<Encuesta> encuestas = new List<Encuesta>();

        public Encuesta EncuestaEnCurso { get; private set; }

        public void IniciarEncuesta(int anio, string localidad)
        {
            EncuestaEnCurso = new Encuesta { Anio=anio, Localidad=localidad};
        }
        public void CerrarEncuesta()
        {
            if (EncuestaEnCurso != null)
            {
                encuestas.Add(EncuestaEnCurso);
                EncuestaEnCurso.ActualizarEstadistica();
                EncuestaEnCurso = null;
            }
        }

    }
}
