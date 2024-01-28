using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioWebASP_POWERBI
{
    public partial class InicioEncuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarEncuesta_Click(object sender, EventArgs e)
        {
            EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();
            
            int anio = Convert.ToInt32(tbANIO.Text);
            string localidad = tbLocalidad.Text;

            manager.IniciarEncuesta(anio, localidad);

            Response.Redirect("Default.aspx");
        }
    }
}