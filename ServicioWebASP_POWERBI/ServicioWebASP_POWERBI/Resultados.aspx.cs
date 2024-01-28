using EncuestasDAO.DAO;
using EncuestasNuevoModels.Models;
using EncuestasSQLServerDaoImpl.SQLServerDaoImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioWebASP_POWERBI
{
    public partial class Resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                if (string.IsNullOrEmpty(Request["idEncuestaCerrada"]) == false)
                {
                    int id = Convert.ToInt32(Request["idEncuestaCerrada"]);

                    IEncuestaDAO encuestaDAO = new EncuestaSQLServerDaoImpl();
                    Encuesta selectedEncuesta = encuestaDAO.BuscarPorId(id);

                    lbAnio.Text = selectedEncuesta.Anio.ToString();
                    lbLocalidad.Text = selectedEncuesta.Localidad;

                    lbCantidadEncuestados.Text = selectedEncuesta.CantidadEncuestados.ToString();

                    lbPorcBicicleta.Text = $"{selectedEncuesta.PorcBicicleta}";
                    lbPorcCaminando.Text = $"{selectedEncuesta.PorcCaminando}";
                    lbPorcTransportePublico.Text = $"{selectedEncuesta.PorcTransportePublico}";
                    lbPorcTransportePrivado.Text = $"{selectedEncuesta.PorcTransportePrivado}";

                    lbDistancia.Text = $"{selectedEncuesta.DistanciaMedia}";
                }

            }
        }
    }
}