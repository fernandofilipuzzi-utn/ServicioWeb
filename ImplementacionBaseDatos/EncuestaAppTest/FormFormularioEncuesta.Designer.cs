
namespace EncuestaAppTest
{
    partial class FormFormularioEncuesta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chbTransportePrivado = new System.Windows.Forms.CheckBox();
            this.chbUsaTransportePublico = new System.Windows.Forms.CheckBox();
            this.chbCaminando = new System.Windows.Forms.CheckBox();
            this.chbUsaBicicleta = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbDistanciaASuLugar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Email";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(177, 32);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(329, 22);
            this.tbEmail.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(193, 358);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Registrar Respuesta";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbEmail);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 96);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(516, 74);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos personales";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbTransportePrivado);
            this.groupBox2.Controls.Add(this.chbUsaTransportePublico);
            this.groupBox2.Controls.Add(this.chbCaminando);
            this.groupBox2.Controls.Add(this.chbUsaBicicleta);
            this.groupBox2.Location = new System.Drawing.Point(16, 177);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(516, 92);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "¿Qué medio de transporte usa más frecuentemente? (tilde una o mas opciones)";
            // 
            // chbTransportePrivado
            // 
            this.chbTransportePrivado.AutoSize = true;
            this.chbTransportePrivado.Location = new System.Drawing.Point(224, 59);
            this.chbTransportePrivado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbTransportePrivado.Name = "chbTransportePrivado";
            this.chbTransportePrivado.Size = new System.Drawing.Size(263, 20);
            this.chbTransportePrivado.TabIndex = 3;
            this.chbTransportePrivado.Text = "¿Otro medio persona? (Motocicleta, etc)";
            this.chbTransportePrivado.UseVisualStyleBackColor = true;
            // 
            // chbUsaTransportePublico
            // 
            this.chbUsaTransportePublico.AutoSize = true;
            this.chbUsaTransportePublico.Location = new System.Drawing.Point(224, 31);
            this.chbUsaTransportePublico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbUsaTransportePublico.Name = "chbUsaTransportePublico";
            this.chbUsaTransportePublico.Size = new System.Drawing.Size(176, 20);
            this.chbUsaTransportePublico.TabIndex = 2;
            this.chbUsaTransportePublico.Text = "¿Usa transporte Público?";
            this.chbUsaTransportePublico.UseVisualStyleBackColor = true;
            // 
            // chbCaminando
            // 
            this.chbCaminando.AutoSize = true;
            this.chbCaminando.Location = new System.Drawing.Point(51, 59);
            this.chbCaminando.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbCaminando.Name = "chbCaminando";
            this.chbCaminando.Size = new System.Drawing.Size(95, 20);
            this.chbCaminando.TabIndex = 1;
            this.chbCaminando.Text = "Caminando";
            this.chbCaminando.UseVisualStyleBackColor = true;
            // 
            // chbUsaBicicleta
            // 
            this.chbUsaBicicleta.AutoSize = true;
            this.chbUsaBicicleta.Location = new System.Drawing.Point(51, 33);
            this.chbUsaBicicleta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbUsaBicicleta.Name = "chbUsaBicicleta";
            this.chbUsaBicicleta.Size = new System.Drawing.Size(119, 20);
            this.chbUsaBicicleta.TabIndex = 0;
            this.chbUsaBicicleta.Text = "¿Usa Bicicleta?";
            this.chbUsaBicicleta.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbDistanciaASuLugar);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(16, 277);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(516, 74);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del lugar de interés";
            // 
            // tbDistanciaASuLugar
            // 
            this.tbDistanciaASuLugar.Location = new System.Drawing.Point(177, 32);
            this.tbDistanciaASuLugar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDistanciaASuLugar.Name = "tbDistanciaASuLugar";
            this.tbDistanciaASuLugar.Size = new System.Drawing.Size(131, 22);
            this.tbDistanciaASuLugar.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Distancia";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbLocalidad);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(16, 15);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(516, 74);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos personales";
            // 
            // cbLocalidad
            // 
            this.cbLocalidad.FormattingEnabled = true;
            this.cbLocalidad.Location = new System.Drawing.Point(177, 28);
            this.cbLocalidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLocalidad.Name = "cbLocalidad";
            this.cbLocalidad.Size = new System.Drawing.Size(332, 24);
            this.cbLocalidad.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Localidad con encuesta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "(Km)";
            // 
            // FormFormularioEncuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 400);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormFormularioEncuesta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormFormularioEncuesta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox tbDistanciaASuLugar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.ComboBox cbLocalidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox chbTransportePrivado;
        public System.Windows.Forms.CheckBox chbUsaTransportePublico;
        public System.Windows.Forms.CheckBox chbCaminando;
        public System.Windows.Forms.CheckBox chbUsaBicicleta;
    }
}