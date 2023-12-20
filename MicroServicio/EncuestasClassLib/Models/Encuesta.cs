using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasClassLib.Models
{
    public class Encuesta
    {
        public string Email { get; set; }
        public bool UsaBicicleta { get; set; }
        public bool UsaAuto { get; set; }
        public bool UsaTransportePublico { get; set; }
        public double DistanciaASuDestino { get; set; }
    }
}
