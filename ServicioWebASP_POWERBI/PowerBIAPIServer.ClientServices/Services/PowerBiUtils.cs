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
        
        public string GetEmbedToken(string urlServer, string reportId, string workspaceId)
        {
               
            string apiUrl = $"{urlServer}/api/v2.0/GenerateToken/Workspace/{workspaceId}/Report/{reportId}";

            string embedToken = string.Empty;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        embedToken = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex) { }

            return embedToken;
        }
    }
}
