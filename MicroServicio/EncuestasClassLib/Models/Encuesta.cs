using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasClassLib.Models
{
    public class Encuesta
    {
        List<Respuesta> respuestas = new List<Respuesta>();

        public int Anio { get; set; }
        public string Localidad { get; set; }
        //
        public double PorcBicleta { get; set; }
        public double PorcAuto { get; set; }
        public double PorcTransportePublico { get; set; }
        public double DistanciaMedia { get; set; }

        public void RegistrarRespuesta(Respuesta nuevo)
        {
            respuestas.Add(nuevo);
        }

        public void ActualizarEstadistica() 
        {
            int bicicletas=0;
            int autos=0;
            int transportePublico=0;
            double distanciaTotal=0;
            foreach (Respuesta respuesta in respuestas)
            {
                if (respuesta.UsaBicicleta)
                    bicicletas++;
                if (respuesta.UsaAuto)
                    autos++;
                if (respuesta.UsaTransportePublico)
                    transportePublico++;

                distanciaTotal += respuesta.DistanciaASuDestino;
            }
            if (respuestas.Count>0)
            {

                PorcBicleta = 100d * bicicletas / respuestas.Count; 
                PorcAuto = 100d * autos / respuestas.Count;
                PorcTransportePublico = 100d * transportePublico / respuestas.Count;
                DistanciaMedia=distanciaTotal / respuestas.Count;
            }
        }
    }
}
