using EncuestasDAO.DAO;
using EncuestasNuevoModels.Models;
using EncuestasSQLServerDaoImpl.SQLServerdaoImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioEncuestas
{
    public partial class FormularioEncuesta : System.Web.UI.Page
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
            try
            {
                EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();

                #region parseo
                string email = tbEmail.Text;
                bool usaBicicleta = ckbUsaBicicleta.Checked;
                bool camina = ckbUsaBicicleta.Checked;
                bool usaTransportePublico = ckbUsaBicicleta.Checked;
                bool usaTransportePrivado = ckbUsaBicicleta.Checked;
                double distanciaASuDestino = Convert.ToDouble(tbDistancia.Text);

                int id= Convert.ToInt32(cbLocalidad.SelectedValue);
                IEncuestaDAO encuestaDAO  = new EncuestaSQLServerDaoImpl();
                Encuesta selectedEncuesta = encuestaDAO.BuscarPorId(id);

                Respuesta nueva = new Respuesta
                {
                    Email = email,
                    UsaBicicleta = usaBicicleta,
                    Camina = camina,
                    UsaTransportePublico = usaTransportePublico,
                    UsaTransportePrivado = usaTransportePrivado,
                    DistanciaASuDestino = distanciaASuDestino
                };
                #endregion

                manager.RegistrarRespuesta(nueva, selectedEncuesta);
                //Response.Redirect("Default.aspx");//vuelve al menú principal
                Response.Redirect("Default.aspx",false);//cuando da error por subproceso anulado
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"{ex.Message}||{ex.StackTrace}", "Error!");
            }
        }
    }
}