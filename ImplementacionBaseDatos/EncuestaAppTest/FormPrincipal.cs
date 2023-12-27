using EncuestasModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();
                       

            if (formInicio.ShowDialog() == DialogResult.OK)
            {
                int anio = Convert.ToInt32(formInicio.tbANIO.Text);
                string localidad = formInicio.tbLocalidad.Text;

                manager.IniciarEncuesta(anio, localidad);
            }
        }

        private void btnRegistrarEncuesta_Click(object sender, EventArgs e)
        {
            try
            {
                FormFormularioEncuesta formRespuesta = new FormFormularioEncuesta();
                EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();

                formRespuesta.cbLocalidad.Items.AddRange(manager.EncuestasEnCurso.ToArray<Encuesta>());

                if (formRespuesta.ShowDialog() == DialogResult.OK)
                {
                    

                    Respuesta nueva = new Respuesta
                    {
                        Email = formRespuesta.tbEmail.Text,
                        UsaBicicleta = false,
                        Camina = false,
                        UsaTransportePublico = false,
                        UsaTransportePrivado = false,
                        DistanciaASuDestino = 23d
                    };

                    manager.RegistrarRespuesta(nueva, formRespuesta.cbLocalidad.SelectedItem as Encuesta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}||{ex.StackTrace}", "Error!");
            }
        }
    }
}
