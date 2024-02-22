using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioEncuestas_design.BackofficeEncuestado
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UsuarioSettings"];

            if (cookie == null)
            {
                Response.Redirect("~/BackofficeEncuestado/login.aspx");
            }
            else
            {
                string usuario = cookie["usuario"];
                if (DateTime.Now < cookie.Expires)
                {
                    Response.Redirect("~/BackofficeEncuestado/Default.aspx");
                    lbUsuarioNombre.Text = usuario;
                }
                else
                {
                    Response.Redirect("~/BackofficeEncuestado/login.aspx");                    
                }
            }
        }

        protected void lbtnCerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
         
            HttpCookie cookie = Request.Cookies["UsuarioSettings"];
      
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("~/Default.aspx");
            //Response.Write("<script>window.location.href = '/Default.aspx';</script>");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "window.location='" + ResolveClientUrl("~/Default.aspx") + "';", true);
        }

        public void ShowMessage(string titulo, string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", $"mostrarModal('{mensaje}');", true);
        }
    }
}