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
        public double PorcCaminando { get; set; }
        public double PorcTransportePublico { get; set; }
        public double PorcTransportePrivado { get; set; }

        public double DistanciaMedia { get; set; }

        public void RegistrarRespuesta(Respuesta nuevo)
        {
            respuestas.Add(nuevo);
        }

        public void ActualizarEstadistica() 
        {
            int bicicletas=0;
            int caminantes=0;
            int transportePublico=0;
            int transportePrivado = 0;

            double distanciaTotal=0;
            foreach (Respuesta respuesta in respuestas)
            {
                if (respuesta.UsaBicicleta)
                    bicicletas++;
                if (respuesta.Camina)
                    caminantes++;
                if (respuesta.UsaTransportePublico)
                    transportePublico++;
                if (respuesta.UsaTransportePrivado)
                    transportePrivado++;

                distanciaTotal += respuesta.DistanciaASuDestino;
            }
            if (respuestas.Count>0)
            {

                PorcBicleta = 100d * bicicletas / respuestas.Count; 
                PorcCaminando = 100d * caminantes / respuestas.Count;
                PorcTransportePublico = 100d * transportePublico / respuestas.Count;
                PorcTransportePrivado = 100d * transportePrivado / respuestas.Count;
                DistanciaMedia =distanciaTotal / respuestas.Count;
            }
        }
    }
}
