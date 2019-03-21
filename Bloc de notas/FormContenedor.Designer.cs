namespace Bloc_de_notas
{
    partial class ShiruNotas
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
            this.btnCrearNota = new System.Windows.Forms.Button();
            this.rtbNota = new System.Windows.Forms.RichTextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.cbIndex = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCrearNota
            // 
            this.btnCrearNota.Location = new System.Drawing.Point(12, 12);
            this.btnCrearNota.Name = "btnCrearNota";
            this.btnCrearNota.Size = new System.Drawing.Size(102, 46);
            this.btnCrearNota.TabIndex = 0;
            this.btnCrearNota.Text = "Crear Nota";
            this.btnCrearNota.UseVisualStyleBackColor = true;
            this.btnCrearNota.Click += new System.EventHandler(this.btnCrearNota_Click);
            // 
            // rtbNota
            // 
            this.rtbNota.Location = new System.Drawing.Point(14, 88);
            this.rtbNota.Name = "rtbNota";
            this.rtbNota.Size = new System.Drawing.Size(511, 470);
            this.rtbNota.TabIndex = 5;
            this.rtbNota.Text = "";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(120, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 46);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tbTitulo
            // 
            this.tbTitulo.Location = new System.Drawing.Point(14, 62);
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.Size = new System.Drawing.Size(181, 20);
            this.tbTitulo.TabIndex = 7;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(365, 12);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(74, 43);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(446, 12);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(79, 43);
            this.btnBorrar.TabIndex = 9;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // cbIndex
            // 
            this.cbIndex.FormattingEnabled = true;
            this.cbIndex.Location = new System.Drawing.Point(365, 62);
            this.cbIndex.Name = "cbIndex";
            this.cbIndex.Size = new System.Drawing.Size(160, 21);
            this.cbIndex.TabIndex = 10;
            // 
            // ShiruNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 570);
            this.Controls.Add(this.cbIndex);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.tbTitulo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.rtbNota);
            this.Controls.Add(this.btnCrearNota);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ShiruNotas";
            this.Text = "ShiruNote 0.4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearNota;
        private System.Windows.Forms.RichTextBox rtbNota;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox tbTitulo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.ComboBox cbIndex;
    }
}

