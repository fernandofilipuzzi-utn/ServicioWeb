using EncuestasDAO.DAO;
using EncuestasModels.Models;
using EncuestasSQLServerDaoImpl.SQLServerdaoImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioEncuestas
{
    public partial class CierreEncuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();
                if (IsPostBack == false)
                { //solo cuando se recargue la página
                    //cbLocalidad.Items.AddRange(manager.EncuestasEnCurso.ToArray<Encuesta>());
                    cbLocalidad.DataSource = manager.EncuestasEnCurso;
                    cbLocalidad.DataBind();
                }
            }
        }

        protected void btnAccion_Click(object sender, EventArgs e)
        {
            EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();

            try 
            {
                int id = Convert.ToInt32(cbLocalidad.SelectedValue);
                IEncuestaDAO encuestaDAO = new EncuestaSQLServerDaoImpl();
                Encuesta selectedEncuesta = encuestaDAO.BuscarPorId(id);

                manager.CerrarEncuesta(selectedEncuesta);

                Response.Redirect($"Resultados.aspx?idEncuestaCerrada={selectedEncuesta.Id}");
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}