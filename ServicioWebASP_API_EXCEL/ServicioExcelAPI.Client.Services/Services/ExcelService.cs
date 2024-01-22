using Microsoft.Web.Administration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ServicioAPI.Client.Services.Services
{
    public class ExcelService
    {

        string url = "http://localhost:5002/api/Excel/GetExcel";

        public static void AjustarLimiteRespuesta(string nombreSitio, long nuevoLimite)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                Microsoft.Web.Administration.Site sitio = serverManager.Sites[nombreSitio];

                if (sitio != null)
                {
                    Configuration configuracionSitio = serverManager.GetWebConfiguration(nombreSitio);
                    ConfigurationSection requestFilteringSection = configuracionSitio.GetSection("system.webServer/security/requestFiltering");

                    ConfigurationElement requestLimitsElement = requestFilteringSection.GetCollection("requestLimits").FirstOrDefault();
                    if (requestLimitsElement != null)
                    {
                        requestLimitsElement["maxAllowedContentLength"] = nuevoLimite;
                    }

                    serverManager.CommitChanges();
                }
            }
        }

        public void GenerarExcel(DataTable dt, HttpResponse @out)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var requestContent = JsonConvert.SerializeObject(dt);
                    int tamanoBytes = Encoding.UTF8.GetBytes(requestContent).Length;

                    var request = new HttpRequestMessage(HttpMethod.Post, url)
                    {
                        Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
                    };
                    request.Headers.Add("Accept", "application/json;utf-8 ");

                    HttpResponseMessage response = client.SendAsync(request).Result;

                    byte[] fileContents = response.Content.ReadAsByteArrayAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        @out.Clear();
                        @out.Buffer = true;
                        @out.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        @out.AddHeader("Content-Disposition", "attachment; filename=Exportacion.xlsx");
                        @out.BinaryWrite(fileContents);
                        @out.Flush();
                        @out.Close();
                        //Response.End();//con eso me da subproceso anulado
                    }
                    else
                    {
                        @out.Clear();
                        @out.Buffer = true;
                        @out.ContentType = "text/html";
                        @out.BinaryWrite(fileContents);
                        @out.Flush();
                        @out.Close();
                    }
                }
                // Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
