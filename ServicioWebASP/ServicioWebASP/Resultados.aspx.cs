using EncuestasDAO.DAO;
using EncuestasModels.Models;
using EncuestasSQLServerDaoImpl.SQLServerdaoImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioEncuestas
{
    public partial class Resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                int id = Convert.ToInt32(Request["idEncuestaCerrada"]);

                IEncuestaDAO encuestaDAO = new EncuestaSQLServerDaoImpl();
                Encuesta selectedEncuesta = encuestaDAO.BuscarPorId(id);

                lbAnio.Text = selectedEncuesta.Anio.ToString();
                lbLocalidad.Text = selectedEncuesta.Localidad;

            }
        }
    }
}