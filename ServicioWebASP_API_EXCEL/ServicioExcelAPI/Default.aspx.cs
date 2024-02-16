using ServicioAPI.Client.Services.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioAPI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExcel1_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:7777/api/Excel/GetExcel";
            try
            { 
                #region ejemplo
                DataSet dataSet = new DataSet();
                DataTable dt = new DataTable();
                dataSet.Tables.Add(dt);
                dt.Columns.Add("A1", typeof(string));
                dt.Columns.Add("B1", typeof(string));
                DataRow fila = dt.NewRow();
                fila["A1"] = "a";
                fila["B1"] = "b";
                dt.Rows.Add(fila);
                fila = dt.NewRow();
                fila["A1"] = "c";
                fila["B1"] = "d";
                dt.Rows.Add(fila);
                #endregion 

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

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportarExcel.aspx");
        }
    }
}