using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioEncuestas
{
    public partial class InicioEncuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarEncuesta_Click(object sender, EventArgs e)
        {
            //hay que buscar un mecanismo para configurar la implementación de dao en el web.config
            //para sqlite
            //string rutaSQLite = Path.Combine( Server.MapPath("~"), "db_encuestas.db");
            //EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager(rutaSQLite);

            //para sqlserver
            EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();

            int anio = Convert.ToInt32(tbANIO.Text);
            string localidad = tbLocalidad.Text;

            manager.IniciarEncuesta(anio, localidad);

            Response.Redirect("Default.aspx");
        }
    }
}