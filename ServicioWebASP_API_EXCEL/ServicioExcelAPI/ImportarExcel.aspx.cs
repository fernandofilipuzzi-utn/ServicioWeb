using ServicioAPI.Client.Services.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioAPI
{
    public partial class ImportarExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {



            if (fuFicheroExcel.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fuFicheroExcel.FileName);
                    string pathUpload = Path.Combine(Server.MapPath("/Uploads/") + filename);
                    fuFicheroExcel.SaveAs(pathUpload);

                    if (File.Exists(pathUpload))
                    {
                        ExcelClientService oService = new ExcelClientService();

                        //libreria para manejar las peticiones a la api que resuelve esto

                        DataSet dt = oService.ImportarExcel(pathUpload);

                        ListView1.DataSource = dt.Tables[0];
                        ListView1.DataBind();

                        //  Response.SuppressContent = true;  // Prevents the HTTP headers from being sent to the client.
                        // HttpContext.Current.ApplicationInstance.CompleteRequest();



                    }
                    else
                    {
                        throw new Exception("Error en el servidor. No se encontró el fichero!.");
                    }
                }
                catch (Exception ex)
                {
                    string mensaje = $"<p>{ex.Message}</p><p>{ex.StackTrace.ToString()}</p>";
                    if (ex.InnerException != null)
                        mensaje += $"<p>{ex.InnerException.Message}</p><p>{ex.InnerException.StackTrace.ToString()}</p>";
                    ((SiteMaster)this.Master).ShowMessage(mensaje, "Error en la solicitud de importación");
                }
            }
        }
    }
}