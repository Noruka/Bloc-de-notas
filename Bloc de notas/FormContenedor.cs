using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bloc_de_notas
{
    public partial class ShiruNotas : Form
    {
        private List<ObjetoNota> Notas = new List<ObjetoNota>();

        private ObjetoNota nota;

        public ShiruNotas()
        {
            InitializeComponent();
        }

        private void btnCrearNota_Click(object sender, EventArgs e)
        {
            ClearNota();
            nota = new ObjetoNota("Nueva Nota", "");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String tituloNotaActual = tbTitulo.Text;
            String contenidoNotaActual = rtbNota.Text;

            if (tituloNotaActual.Equals(""))
            {
                MessageBox.Show("No has insertado titulo");
            }
            else if (ComprobarExiste(tituloNotaActual))
            {
                int pos = 0;

                for (int i = 0; i < Notas.Count; i++)
                {
                    if (Notas[i].Titulo.Equals(tituloNotaActual))
                    {
                        pos = i;
                        break;
                    }
                }

                Notas[pos].SetNota(tituloNotaActual, contenidoNotaActual);
            }
            else
            {
                nota = new ObjetoNota(tituloNotaActual, contenidoNotaActual);
                Notas.Add(nota);
                AnyadirItem(tituloNotaActual);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int i = cbIndex.SelectedIndex;

            if (cbIndex.Items.Count!=0)
            {
                ClearNota();
                tbTitulo.Text = Notas[i].Titulo;
                rtbNota.Text = Notas[i].Contenido;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int i = cbIndex.SelectedIndex;

            if (cbIndex.Items.Count != 0)
            {
                Notas.RemoveAt(i);
                cbIndex.Items.RemoveAt(i);
            }
        }

        private void ClearNota()
        {
            tbTitulo.Text = "";
            rtbNota.Text = "";
        }

        private Boolean ComprobarExiste(String t)
        {
            for (int i = 0; i < Notas.Count; i++)
            {
                if (Notas[i].Titulo.Equals(t))
                {
                    return true;
                }
            }
            return false;
        }

        private void AnyadirItem(String titulo)
        {
            cbIndex.Items.Add(titulo);
        }
    }
}