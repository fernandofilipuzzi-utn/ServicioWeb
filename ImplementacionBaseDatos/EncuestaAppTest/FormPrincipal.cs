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

        private void button1_Click(object sender, EventArgs e)
        {
            FormInicioEncuesta formInicio = new FormInicioEncuesta();
            if (formInicio.ShowDialog() == DialogResult.OK)
            {
                EncuestaServicio.Services.EncuestaManager manager = new EncuestaServicio.Services.EncuestaManager();

                int anio = Convert.ToInt32(formInicio.tbANIO.Text);
                string localidad = formInicio.tbLocalidad.Text;

                manager.IniciarEncuesta(anio, localidad);
            }
        }
    }
}
