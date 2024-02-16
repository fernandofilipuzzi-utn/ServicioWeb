using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioAPI
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowMessage(string mensaje, string titulo="Mensaje")
        {
            string mensajeEncoded = HttpUtility.HtmlEncode(mensaje);
            //            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", $"showMessage('<![CDATA[{mensaje}]]','{titulo}');", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", $"showMessage('{mensajeEncoded}','{titulo}');", true);

        }
    }
}