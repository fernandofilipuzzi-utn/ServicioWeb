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

        protected void btnExcel1_Click(object sender, EventArgs e)
        {
            try
            {
                EncuestaSQLServerDaoImpl encuestaDAO = new EncuestaSQLServerDaoImpl();

                DataTable dt = encuestaDAO.ListarEncuestas().Tables[0];

                /*libreria para manejar las peticiones a la api que resuelve esto*/
                ExcelClientService oService = new ExcelClientService();

                oService.ExportarAExcel(dt, Response);

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
         * */
        protected void btnExcel2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes("kk");
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "text/html";
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();

                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                string errores = HttpUtility.HtmlEncode($"{ex.Message}|{ex.StackTrace}");
                if (ex.InnerException != null)
                    errores += HttpUtility.HtmlEncode($"{ex.InnerException.Message}|{ex.InnerException.StackTrace}");

                ((SiteMaster)this.Master).ShowMessage("Error", errores);
            }
        }


        protected void btnImportar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportarExcel.aspx");
        }
    }
}