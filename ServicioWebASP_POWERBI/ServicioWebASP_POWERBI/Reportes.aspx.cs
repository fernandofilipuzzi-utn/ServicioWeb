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
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string urlReportServer = "https://localhost";
                string pathDirectorioVirtual = "ReportesWeb";//ir a report server configuration > dirección url del portal web
                //
                string embedToken = "";
                #region datos identificatorios para esta generación
                string reporteId = "prueba2";
                string workspaceId = "prueba";
                embedToken = new PowerBiUtils().GetEmbedToken(urlReportServer, reporteId, workspaceId);
                #endregion
                //
                string raiz = "powerbi";//desde la web ser ve
                string pathReporte = "prueba2";//ver en http://tsp/ReportServices o en el la web
                string pathReporteCompleto = $@"{raiz}/{pathReporte}";

                iframeControl.Attributes["src"] = $"{urlReportServer}/{pathDirectorioVirtual}/{pathReporteCompleto}?rs:embed=true";// &embedToken={embedToken}";
            }
        }
    }
}