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
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.rtbNota = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbTitulo
            // 
            this.tbTitulo.Location = new System.Drawing.Point(12, 27);
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.Size = new System.Drawing.Size(436, 20);
            this.tbTitulo.TabIndex = 1;
            // 
            // rtbNota
            // 
            this.rtbNota.Location = new System.Drawing.Point(13, 54);
            this.rtbNota.Name = "rtbNota";
            this.rtbNota.Size = new System.Drawing.Size(435, 384);
            this.rtbNota.TabIndex = 2;
            this.rtbNota.Text = "";
            // 
            // ShiruNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 450);
            this.Controls.Add(this.rtbNota);
            this.Controls.Add(this.tbTitulo);
            this.Name = "ShiruNote";
            this.Text = "ShiruNote 0.7.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShiruNote_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbTitulo;
        private System.Windows.Forms.RichTextBox rtbNota;
    }
}