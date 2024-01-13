using EncuestasDAO.DAO;
using EncuestasNuevoModels.Models;
using EncuestasSQLiteDaoImpl.SQLiteDaoImpl;
using EncuestasSQLServerDaoImpl.SQLServerDaoImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestaServicio.Services
{
    public class EncuestaManager
    {
        //inyección!
        /* sqlserver
        IEncuestaDAO encuestaDAO { get; set; } = new EncuestaSQLServerDaoImpl();
        IRespuestaDAO respuestaDAO { get; set; } = new RespuestaSQLServerDaoImpl();
        */
        /* sqlite*/
        public IEncuestaDAO encuestaDAO { get; set; } 
        public IRespuestaDAO respuestaDAO { get; set; } 

        public EncuestaManager()
        {
            /* inyección por constructor*/
            encuestaDAO  = new EncuestaSQLServerDaoImpl();
            respuestaDAO =new RespuestaSQLServerDaoImpl();
           /*
            encuestaDAO = new EncuestaSQLiteDaoImpl();
            respuestaDAO = new RespuestaSQLiteDaoImpl();
            */
        }

        public EncuestaManager(string pathSQLite)
        {
            encuestaDAO = new EncuestaSQLiteDaoImpl(pathSQLite);
            respuestaDAO = new RespuestaSQLiteDaoImpl(pathSQLite);
        }


        public List<Encuesta> EncuestasEnCurso 
        {
            get {
                return encuestaDAO.BuscarUltimasEncuestaNoCerradas();
            }
        }

        public void IniciarEncuesta(int anio, string localidad)
        {
            Encuesta nueva = new Encuesta { Anio=anio, Localidad=localidad, EnCurso=true};
            encuestaDAO.Agregar(nueva);
        }

        public void CerrarEncuesta(Encuesta encuestaEnCurso)
        {
            if (encuestaEnCurso != null)
            {
                //encuestaEnCurso.ActualizarEstadistica();
                ActualizarEstadistica(encuestaEnCurso);
                encuestaEnCurso.EnCurso = false;
                encuestaDAO.Actualizar(encuestaEnCurso);
            }
        }

        public void ActualizarEstadisticasEnCurso()
        {
            List<Encuesta> encuestas = encuestaDAO.BuscarUltimasEncuestaNoCerradas();
            foreach (Encuesta encuesta in encuestas)
            {
                ActualizarEstadistica(encuesta);
                encuestaDAO.Actualizar(encuesta);
            }
        }

        public void ActualizarEstadistica(Encuesta encuesta)
        {
            List<Respuesta> respuestas = respuestaDAO.BuscarPorIdEncuesta(encuesta.Id);

            int bicicletas = 0;
            int caminantes = 0;
            int transportePublico = 0;
            int transportePrivado = 0;

            double distanciaTotal = 0;
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
            encuesta.respuestas.AddRange(respuestas);
            //
            encuesta.PorcBicicleta = 0;
            encuesta.PorcCaminando = 0;
            encuesta.PorcTransportePublico = 0;
            encuesta.PorcTransportePrivado = 0;
            encuesta.DistanciaMedia = 0;
            if (respuestas.Count > 0)
            {
                encuesta.PorcBicicleta = 100d * bicicletas / encuesta.CantidadEncuestados;
                encuesta.PorcCaminando = 100d * caminantes / encuesta.CantidadEncuestados;
                encuesta.PorcTransportePublico = 100d * transportePublico / encuesta.CantidadEncuestados;
                encuesta.PorcTransportePrivado = 100d * transportePrivado / encuesta.CantidadEncuestados;
                encuesta.DistanciaMedia = distanciaTotal / encuesta.CantidadEncuestados;
            }
        }

        public void RegistrarRespuesta(Respuesta nuevo, Encuesta aDonde)
        {
            respuestaDAO.Agregar(nuevo, aDonde);
        }
    }
}
