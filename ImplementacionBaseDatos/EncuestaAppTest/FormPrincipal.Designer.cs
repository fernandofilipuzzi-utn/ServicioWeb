
namespace EncuestaAppTest
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIniciarEncuesta = new System.Windows.Forms.Button();
            this.btnRegistrarEncuesta = new System.Windows.Forms.Button();
            this.btnCerrarEncuesta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIniciarEncuesta
            // 
            this.btnIniciarEncuesta.Location = new System.Drawing.Point(57, 36);
            this.btnIniciarEncuesta.Name = "btnIniciarEncuesta";
            this.btnIniciarEncuesta.Size = new System.Drawing.Size(249, 47);
            this.btnIniciarEncuesta.TabIndex = 0;
            this.btnIniciarEncuesta.Text = "Iniciar Nueva Encuesta";
            this.btnIniciarEncuesta.UseVisualStyleBackColor = true;
            this.btnIniciarEncuesta.Click += new System.EventHandler(this.btnIniciarEncuesta_Click);
            // 
            // btnRegistrarEncuesta
            // 
            this.btnRegistrarEncuesta.Location = new System.Drawing.Point(57, 142);
            this.btnRegistrarEncuesta.Name = "btnRegistrarEncuesta";
            this.btnRegistrarEncuesta.Size = new System.Drawing.Size(249, 47);
            this.btnRegistrarEncuesta.TabIndex = 1;
            this.btnRegistrarEncuesta.Text = "Registrar Encuesta";
            this.btnRegistrarEncuesta.UseVisualStyleBackColor = true;
            this.btnRegistrarEncuesta.Click += new System.EventHandler(this.btnRegistrarEncuesta_Click);
            // 
            // btnCerrarEncuesta
            // 
            this.btnCerrarEncuesta.Location = new System.Drawing.Point(57, 89);
            this.btnCerrarEncuesta.Name = "btnCerrarEncuesta";
            this.btnCerrarEncuesta.Size = new System.Drawing.Size(249, 47);
            this.btnCerrarEncuesta.TabIndex = 2;
            this.btnCerrarEncuesta.Text = "Cerrar Encuesta";
            this.btnCerrarEncuesta.UseVisualStyleBackColor = true;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 238);
            this.Controls.Add(this.btnCerrarEncuesta);
            this.Controls.Add(this.btnRegistrarEncuesta);
            this.Controls.Add(this.btnIniciarEncuesta);
            this.Name = "FormPrincipal";
            this.Text = "Mi ministerio de transporte";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarEncuesta;
        private System.Windows.Forms.Button btnRegistrarEncuesta;
        private System.Windows.Forms.Button btnCerrarEncuesta;
    }
}

