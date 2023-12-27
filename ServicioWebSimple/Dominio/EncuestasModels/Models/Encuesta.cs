using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasModels.Models
{
    public class Encuesta
    {
        List<Respuesta> respuestas = new List<Respuesta>();

        public int Id { get; set; }
        public int Anio { get; set; }
        public string Localidad { get; set; }
        //
        public double PorcBicleta { get; set; }
        public double PorcCaminando { get; set; }
        public double PorcTransportePublico { get; set; }
        public double PorcTransportePrivado { get; set; }

        public double DistanciaMedia { get; set; }
        public bool EnCurso { get; set; }

        public int CantidadEncuestados 
        {
            get
            {
                return respuestas.Count;
            }
        }

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
            if (CantidadEncuestados > 0)
            {

                PorcBicleta = 100d * bicicletas / CantidadEncuestados;
                PorcCaminando = 100d * caminantes / CantidadEncuestados;
                PorcTransportePublico = 100d * transportePublico / CantidadEncuestados;
                PorcTransportePrivado = 100d * transportePrivado / CantidadEncuestados;
                DistanciaMedia =distanciaTotal / CantidadEncuestados;
            }
        }

        public override string ToString()
        {
            return $"{Localidad}({Anio})";
        }
    }
}
