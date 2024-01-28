using PowerBIAPIServer.ClientServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioWebASP_POWERBI
{
    public partial class Reportes : System.Web.UI.Page
    {
        /*
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // obtenemos el embed token y asignar al control Object
                string embedToken = GetEmbedToken();
                objectControl.Attributes["data"] = $"http://localhost:8000/Reports/powerbi/prueba?rs:embed=true&embedToken={embedToken}";
            }
        }
        */

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PowerBiUtils utils = new PowerBiUtils();                
                string embedToken = utils.GetEmbedToken("ID_DE_REPORTE");
                iframeControl.Attributes["src"] = $"http://localhost:8000/Reports/powerbi/prueba?rs:embed=true&embedToken={embedToken}";
            }
        }
    }
}