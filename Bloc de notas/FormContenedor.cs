using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bloc_de_notas
{
    public partial class ShiruNotas : Form
    {
        private List<ObjetoNota> Notas = new List<ObjetoNota>();

        public ShiruNotas()
        {
            InitializeComponent();
        }

        private void btnCrearNota_Click(object sender, EventArgs e)
        {
            tbTitulo.Text = "";
            rtbNota.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tbTitulo.Text.Equals(""))
            {
                MessageBox.Show("Inserte un titulo para poder guardar");
            }
            else
            {
                ObjetoNota nota = new ObjetoNota();

                nota.Titulo = tbTitulo.Text;
                nota.Contenido = rtbNota.Text;

                Notas.Add(nota);

                cbIndex.Items.Add(nota.Titulo);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int i = cbIndex.SelectedIndex;

            tbTitulo.Text = Notas[i].Titulo;
            rtbNota.Text = Notas[i].Contenido;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int i = cbIndex.SelectedIndex;

            Notas.RemoveAt(i);
            cbIndex.Items.RemoveAt(i);

            tbTitulo.Text = "";
            rtbNota.Text = "";
        }
    }
}