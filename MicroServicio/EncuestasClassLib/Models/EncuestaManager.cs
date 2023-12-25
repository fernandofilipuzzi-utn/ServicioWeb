using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasClassLib.Models
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

        public void RegistrarEncuesta(Respuesta nuevo)
        {
            EncuestaEnCurso.RegistrarRespuesta(nuevo);
        }
    }
}
