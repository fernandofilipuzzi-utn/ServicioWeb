using EncuestasNuevoModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EncuestaAppTest
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnIniciarEncuesta_Click(object sender, EventArgs e)
        {
            FormInicioEncuesta formInicio = new FormInicioEncuesta();

            try
            {
                //sqlserver
                //EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();

                //sqlite
                string pathDBSqlite = "db_encuestas.db";
                EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager(pathDBSqlite);


                if (formInicio.ShowDialog() == DialogResult.OK)
                {
                    int anio = Convert.ToInt32(formInicio.tbANIO.Text);
                    string localidad = formInicio.tbLocalidad.Text;

                    manager.IniciarEncuesta(anio, localidad);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}||{ex.StackTrace}", "Error!");
            }
        }

        private void btnRegistrarEncuesta_Click(object sender, EventArgs e)
        {
            try
            {
                //sqlserver
                //EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();

                //sqlite
                string pathDBSqlite = "db_encuestas.db";
                EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager(pathDBSqlite);


                FormFormularioEncuesta formRespuesta = new FormFormularioEncuesta();
                
                formRespuesta.cbLocalidad.Items.AddRange(manager.EncuestasEnCurso.ToArray<Encuesta>());

                if (formRespuesta.ShowDialog() == DialogResult.OK)
                {
                    #region parseo
                    string email = formRespuesta.tbEmail.Text;
                    bool usaBicicleta = formRespuesta.chbUsaBicicleta.Checked;
                    bool camina = formRespuesta.chbUsaBicicleta.Checked;
                    bool usaTransportePublico = formRespuesta.chbUsaBicicleta.Checked;
                    bool usaTransportePrivado = formRespuesta.chbUsaBicicleta.Checked;
                    double distanciaASuDestino = Convert.ToDouble(formRespuesta.tbDistanciaASuLugar.Text);
                    Encuesta selectedEncuesta = formRespuesta.cbLocalidad.SelectedItem as Encuesta;

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}||{ex.StackTrace}", "Error!");
            }
        }

        private void btnCerrarEncuesta_Click(object sender, EventArgs e)
        {
            FormCierreEncuesta formCierreEncuesta = new FormCierreEncuesta();

            //sqlserver
            //EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();

            //sqlite
            string pathDBSqlite = "db_encuestas.db";
            EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager(pathDBSqlite);

            formCierreEncuesta.cbLocalidad.Items.AddRange(manager.EncuestasEnCurso.ToArray<Encuesta>());
            try
            {
                if (formCierreEncuesta.ShowDialog() == DialogResult.OK)
                {
                    Encuesta seleccionada = formCierreEncuesta.cbLocalidad.SelectedItem as Encuesta;
                    manager.CerrarEncuesta(seleccionada);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}||{ex.StackTrace}", "Error!");
            }
        }
    }
}
