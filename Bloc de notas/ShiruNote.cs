using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bloc_de_notas
{
    public partial class ShiruNote : Form
    {
        //Creamos un List para guardar los objetos de tipo ObjetoNota que contendran
        //el titulo y el contenido.
        private List<ObjetoNota> Notas = new List<ObjetoNota>();

        //Creo el objeto nota para trabajar con él pero
        //no lo inizializo
        private ObjetoNota nota;

        public ShiruNote()
        {
            InitializeComponent();
        }

        //Boton del MenuStrip para limpiar los contenidos.
        private void CrearNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearContenidos();
        }

        //Funcion que limpia los paneles de texto
        private void ClearContenidos()
        {
            tbTitulo.Text = "";
            rtbNota.Text = "";
        }

        //Comprueba si existe el objeto en el array
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

        //Funcion para añadir notas al combobox.
        private void AnyadirItemsCB(String titulo)
        {
            toolStripCBLista.Items.Add(titulo);
            toolStripCBBorrar.Items.Add(titulo);
        }

        //Funcion para borrar notas del combobox y el List
        private void BorrarItemsCB(int pos)
        {
            Notas.RemoveAt(pos);
            toolStripCBLista.Items.RemoveAt(pos);
            toolStripCBBorrar.Items.RemoveAt(pos);
        }

        //Esta funcion guarda el objeto nota en la lista de objetos.
        //Importa los textos de los paneles y comprueba si ya se ha creado una nota
        //con ese texto. Si ya existe lo sobreescribira, si no lo guardara como una nota nueva
        //Si no tiene titulo no dejara guardar la nota.
        private void GuardarToolStripMenuItem_Click(object sender, EventArgs e)
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
                MessageBox.Show("Sobreescrito nota existente con titulo: " + tituloNotaActual);
                ClearContenidos();
            }
            else
            {
                nota = new ObjetoNota(tituloNotaActual, contenidoNotaActual);
                Notas.Add(nota);
                AnyadirItemsCB(tituloNotaActual);
                MessageBox.Show("Se ha creado la nota con titulo: " + tituloNotaActual);
                ClearContenidos();
            }
        }

        //Aqui accedemos al array mediante el combobox para seleccionar una nota reciente y poder cargarla
        //a los paneles para poder editarla. Si se modifica el titulo el boton de guardar la guardara como nota nueva
        //o sobrescribiendo en caso de que otra nota tenga el mismo nombre.
        private void ToolStripCBLista_DropDownClosed(object sender, EventArgs e)
        {
            if (toolStripCBLista.Items.Count == 0)
            {
                MessageBox.Show("No hay nada guardado en la lista");
            }
            else
            {
                if (toolStripCBLista.SelectedIndex == -1)

                {
                    MessageBox.Show("Seleccione un contenido");
                }
                else
                {
                    if (ComprobarExiste(Notas[toolStripCBLista.SelectedIndex].Titulo))
                    {
                        ClearContenidos();
                        tbTitulo.Text = Notas[toolStripCBLista.SelectedIndex].Titulo;
                        rtbNota.Text = Notas[toolStripCBLista.SelectedIndex].Contenido;
                    }
                    else
                    {
                        MessageBox.Show("El contenido seleccionado no existe");
                    }
                }
            }
        }

        //Borra el objeto del array y del combobox seleccionada
        private void ToolStripCBBorrar_DropDownClosed(object sender, EventArgs e)
        {
            int i = toolStripCBBorrar.SelectedIndex;

            if (toolStripCBLista.Items.Count != 0 && i != -1)
            {
                MessageBox.Show("Se ha borrado " + Notas[i].Titulo);
                BorrarItemsCB(i);

                //Limita el tamaño y limpia el texto del combobox.
                if (toolStripCBLista.Items.Count != 0)
                {
                    toolStripCBLista.MaxDropDownItems = toolStripCBLista.Items.Count;
                }
                else
                {
                    toolStripCBLista.Text = "";
                }

                ClearContenidos();
            }
        }
    }
}