using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PowerBIAPIServer.ClientServices.Services
{
    public class PowerBiUtils
    {
        /// <summary>
        /// Obtener token de acceso a powerbi
        /// </summary>
        /// <returns></returns>
        public string GetEmbedToken(string reportId)
        {
            string workspaceId = "ESPACIO_DE_TRABAJO";
            //string reportId = "ID_DE_REPORTE";
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
