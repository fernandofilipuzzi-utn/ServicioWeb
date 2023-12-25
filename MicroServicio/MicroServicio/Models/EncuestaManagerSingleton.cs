using EncuestasClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasClassLib
{
    public class EncuestaManagerSingleton
    {
        static EncuestaManager instancia;
        public static EncuestaManager Instancia
        {
            get 
            {
                if (instancia == null)
                {
                    instancia = new EncuestaManager();
                }
                return instancia;
            }
        }
    }
}
