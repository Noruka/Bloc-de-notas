namespace Bloc_de_notas
{
    partial class ShiruNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiruNote));
            this.msMenuHorizontal = new System.Windows.Forms.MenuStrip();
            this.crearNotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCBLista = new System.Windows.Forms.ToolStripComboBox();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCBBorrar = new System.Windows.Forms.ToolStripComboBox();
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.rtbNota = new System.Windows.Forms.RichTextBox();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.msMenuHorizontal.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenuHorizontal
            // 
            this.msMenuHorizontal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMenuHorizontal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearNotaToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.borrarToolStripMenuItem});
            this.msMenuHorizontal.Location = new System.Drawing.Point(0, 0);
            this.msMenuHorizontal.Name = "msMenuHorizontal";
            this.msMenuHorizontal.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.msMenuHorizontal.Size = new System.Drawing.Size(613, 28);
            this.msMenuHorizontal.TabIndex = 0;
            this.msMenuHorizontal.Text = "menuStrip1";
            // 
            // crearNotaToolStripMenuItem
            // 
            this.crearNotaToolStripMenuItem.Name = "crearNotaToolStripMenuItem";
            this.crearNotaToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.crearNotaToolStripMenuItem.Text = "Crear Nota";
            this.crearNotaToolStripMenuItem.Click += new System.EventHandler(this.CrearNotaToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.GuardarToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCBLista});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // toolStripCBLista
            // 
            this.toolStripCBLista.Name = "toolStripCBLista";
            this.toolStripCBLista.Size = new System.Drawing.Size(121, 28);
            this.toolStripCBLista.DropDownClosed += new System.EventHandler(this.ToolStripCBLista_DropDownClosed);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCBBorrar});
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.borrarToolStripMenuItem.Text = "Borrar";
            // 
            // toolStripCBBorrar
            // 
            this.toolStripCBBorrar.Name = "toolStripCBBorrar";
            this.toolStripCBBorrar.Size = new System.Drawing.Size(121, 28);
            this.toolStripCBBorrar.DropDownClosed += new System.EventHandler(this.ToolStripCBBorrar_DropDownClosed);
            // 
            // tbTitulo
            // 
            this.tbTitulo.Location = new System.Drawing.Point(16, 33);
            this.tbTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.Size = new System.Drawing.Size(580, 22);
            this.tbTitulo.TabIndex = 1;
            // 
            // rtbNota
            // 
            this.rtbNota.Location = new System.Drawing.Point(17, 66);
            this.rtbNota.Margin = new System.Windows.Forms.Padding(4);
            this.rtbNota.Name = "rtbNota";
            this.rtbNota.Size = new System.Drawing.Size(579, 472);
            this.rtbNota.TabIndex = 2;
            this.rtbNota.Text = "";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // ShiruNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 554);
            this.Controls.Add(this.rtbNota);
            this.Controls.Add(this.tbTitulo);
            this.Controls.Add(this.msMenuHorizontal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenuHorizontal;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShiruNote";
            this.Text = "ShiruNote x";
            this.msMenuHorizontal.ResumeLayout(false);
            this.msMenuHorizontal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenuHorizontal;
        private System.Windows.Forms.ToolStripMenuItem crearNotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.TextBox tbTitulo;
        private System.Windows.Forms.RichTextBox rtbNota;
        private System.Windows.Forms.ToolStripComboBox toolStripCBLista;
        private System.Windows.Forms.ToolStripComboBox toolStripCBBorrar;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
    }
}