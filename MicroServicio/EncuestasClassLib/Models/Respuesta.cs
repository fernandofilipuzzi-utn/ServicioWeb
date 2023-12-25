using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasClassLib.Models
{
    public class Respuesta
    {
        //datos personales
        public string Email { get; set; }
        //
        //sobre medios de transportes usados
        public bool UsaBicicleta { get; set; }
        public bool Camina { get; set; }
        public bool UsaTransportePublico { get; set; }
        public bool UsaTransportePrivado { get; set; }
        //
        //sobre la distancia al trabajo o lugar de estudio
        public double DistanciaASuDestino { get; set; }
    }
}
