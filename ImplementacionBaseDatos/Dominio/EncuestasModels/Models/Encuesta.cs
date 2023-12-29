using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasNuevoModels.Models
{
    public class Encuesta
    {
        public List<Respuesta> respuestas { get; set; }= new List<Respuesta>();

        public int Id { get; set; }
        public int Anio { get; set; }
        public string Localidad { get; set; }
        //
        public double? PorcBicleta { get; set; }
        public double? PorcCaminando { get; set; }
        public double? PorcTransportePublico { get; set; }
        public double? PorcTransportePrivado { get; set; }

        public double? DistanciaMedia { get; set; }

        public bool EnCurso { get; set; }

        public int CantidadEncuestados 
        {
            get
            {
                return respuestas.Count;
            }
        }

        public override string ToString()
        {
            return $"{Localidad}({Anio})";
        }
    }
}
