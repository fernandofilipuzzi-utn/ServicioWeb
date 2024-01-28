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
                // Al cargar la página, obtenemos el embed token y lo asignamos al control iframe
                string embedToken = GetEmbedToken();
                iframeControl.Attributes["src"] = $"http://localhost:8000/Reports/powerbi/prueba?rs:embed=true&embedToken={embedToken}";
            }
        }

        private string GetEmbedToken()
        {
            // obtener el token

            string workspaceId = "ESPACIO_DE_TRABAJO";
            string reportId = "ID_DE_REPORTE";
            string apiUrl = $"http://localhost:8000/api/v2.0/GenerateToken/Workspace/{workspaceId}/Report/{reportId}";

            string embedToken = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                // autorización si es necesario
                // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "TOKEN_DE_AUTORIZACION");

                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    embedToken = response.Content.ReadAsStringAsync().Result;
                }
            }

            return embedToken;
        }
    }
}