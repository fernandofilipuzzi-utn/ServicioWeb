using EncuestasNuevoModels.Models;
using EncuestasSQLServerDaoImpl.SQLServerDaoImpl;
using Newtonsoft.Json;
using ServicioAPI.Client.Services.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioEncuestasAPIClient
{
    public partial class _Default : Page
    {

        string url = "http://localhost:5002/api/Excel/GetExcel";

        protected void Page_Load(object sender, EventArgs e)
        { 
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                EncuestaSQLServerDaoImpl encuestaDAO = new EncuestaSQLServerDaoImpl();

                DataTable dt = encuestaDAO.ListarEncuestas().Tables[0];

                ExcelService oService = new ExcelService();

                oService.GenerarExcel(dt, Response);

                Response.SuppressContent = true;  // Prevents the HTTP headers from being sent to the client.
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                string errores = HttpUtility.HtmlEncode($"{ex.Message}|{ex.StackTrace}");
                if (ex.InnerException != null)
                    errores += HttpUtility.HtmlEncode($"{ex.InnerException.Message}|{ex.InnerException.StackTrace}");

                ((SiteMaster)this.Master).ShowMessage("Error", errores);
            }
        }

        /*
         * esta forma solo anda desde el depurador, algo pasa en el IIS
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                EncuestaSQLServerDaoImpl encuestaDAO = new EncuestaSQLServerDaoImpl();

                DataTable dt = encuestaDAO.ListarEncuestas().Tables[0];

                using (HttpClient client = new HttpClient())
                {
                    var requestContent = JsonConvert.SerializeObject(dt);
                    //

                    var request = new HttpRequestMessage(HttpMethod.Post, url)
                    {
                        Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
                    };
                    request.Headers.Add("Accept", "application/json;utf-8 ");

                    HttpResponseMessage response = client.SendAsync(request).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        byte[] fileContents = response.Content.ReadAsByteArrayAsync().Result;

                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("Content-Disposition", "attachment; filename=Exportacion.xlsx");
                        Response.BinaryWrite(fileContents);
                        Response.Flush();
                        Response.End();//con eso me da subproceso anulado

                        //nota
                        //The remote host closed the connection. The error code is 0x800704CD.
                        

        Response.SuppressContent = true;  // Prevents the HTTP headers from being sent to the client.
                        HttpContext.Current.ApplicationInstance.CompleteRequest();  // Ends execution of the current page and starts a new request.
                    }
                    else
                    {
                        byte[] fileContents = response.Content.ReadAsByteArrayAsync().Result;

                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "text/html";
                        Response.BinaryWrite(fileContents);
                        Response.Flush();
                       Response.SuppressContent = true;
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                }
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
            }
        }
*/
    }
}