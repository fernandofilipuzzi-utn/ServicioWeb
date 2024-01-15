using ServicioAPI.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ServicioAPI.Controllers
{
    public class ExcelController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetExcel( [FromBody] DataTable dt)
        {
            HttpResponseMessage result = null;
            try
            {
                if (dt==null)
                {
                    var badRequestResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Los parámetros no son adecuados.")
                    };

                    return badRequestResponse;
                }

                #region generacion excel
                GenerarExcelNPOI generador = new GenerarExcelNPOI();

                byte[] bytes = generador.GenerarExcel(dt, GenerarExcelNPOI.TipoFormato.XLSX);
                string mimeType = generador.GetMimeType(GenerarExcelNPOI.TipoFormato.XLSX);

                result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(bytes, 0, bytes.Length) };
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = $"cenat{DateTime.Now:yymmddHHMMss}.xls" };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
                #endregion
            }
            catch (Exception ex)
            {
                string html = "";
                html = $"<h4>{ex.Message}</h4>" +
                        $" <p>{ex.StackTrace}</p>";
                
                if (ex.InnerException != null)
                {
                    html += $"<h4>{ex.InnerException.Message}</h4>" +
                             $"<p>{ex.InnerException.Message}</p>";
                }
                result = new HttpResponseMessage(HttpStatusCode.InternalServerError) 
                { Content = new StringContent(html) };
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = $"error.html" };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            }
            return result;
        }
    }
}
