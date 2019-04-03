using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bloc_de_notas
{
    public partial class ShiruNotas : Form
    {
        //Aqui creo una lista de tipo ObjetoNota, para guardar las notas que se crean.
        private List<ObjetoNota> Notas = new List<ObjetoNota>();

        //Aqui inicializo el objeto nota para trabaar con él. Si tengo que crear una nota nueva la creo abajo.
        private ObjetoNota nota;

        public ShiruNotas()
        {
            InitializeComponent();
        }

        //Esta funcion crea una nota nueva sin guardar automaticamente la que tienes presente.
        //Basicamente Limpia la clase sobre la que se esta trabajando y limpia los paneles para insertar texto
        private void btnCrearNota_Click(object sender, EventArgs e)
        {
            ClearContenidos();
        }

        //Esta funcion guarda el objeto nota en la lista de objetos.
        //Importa los textos de los paneles y comprueba si ya se ha creado una nota
        //con ese texto. Si ya existe lo sobreescribira, si no lo guardara como una nota nueva
        //Si no tiene titulo no dejara guardar la nota.
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
                MessageBox.Show("Sobreescrito nota existente con titulo: " + tituloNotaActual);
                ClearContenidos();
            }
            else
            {
                nota = new ObjetoNota(tituloNotaActual, contenidoNotaActual);
                Notas.Add(nota);
                AnyadirItem(tituloNotaActual);
                MessageBox.Show("Se ha creado la nota con titulo: " + tituloNotaActual);
                ClearContenidos();
            }
        }

        //Aqui accedemos al array mediante el combobox para seleccionar una nota reciente y poder cargarla
        //a los paneles para poder editarla. Si se modifica el titulo el boton de guardar la guardara como nota nueva
        //o sobrescribiendo en caso de que otra nota tenga el mismo nombre.
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cbIndex.Items.Count == 0)
            {
                MessageBox.Show("No hay nada guardado en la lista");
            }
            else
            {
                if (cbIndex.SelectedIndex == -1)

                {
                    MessageBox.Show("Seleccione un contenido");
                }
                else
                {
                    if (ComprobarExiste(Notas[cbIndex.SelectedIndex].Titulo))
                    {
                        ClearContenidos();
                        tbTitulo.Text = Notas[cbIndex.SelectedIndex].Titulo;
                        rtbNota.Text = Notas[cbIndex.SelectedIndex].Contenido;
                    }
                    else
                    {
                        MessageBox.Show("El contenido seleccionado no existe");
                    }
                }
            }
        }

        //Borra el objeto del array y del combobox seleccionada
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int i = cbIndex.SelectedIndex;

            if (cbIndex.Items.Count != 0 && i != -1)
            {
                Notas.RemoveAt(i);
                cbIndex.Items.RemoveAt(i);
                if (cbIndex.Items.Count != 0)
                {
                    cbIndex.MaxDropDownItems = cbIndex.Items.Count;
                }
                else {
                    cbIndex.Text = "";
                }

                ClearContenidos();
            }
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
        private void AnyadirItem(String titulo)
        {
            cbIndex.Items.Add(titulo);
        }
    }
}