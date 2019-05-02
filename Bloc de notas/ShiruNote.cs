using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bloc_de_notas
{
    public partial class ShiruNote : Form
    {
        public ShiruNote()
        {
            InitializeComponent();
            //version
            this.Text = "ShiruNote " + "0.7.6";
            CargarFichero();
        }

        

        //--------
        //config (CAMBIAR ESTO PUEDE ROMPER ARCHIVOS YA EXISTENTES)
        private String FINFICHERO = "END!";

        private char SEPARADOR = '$';

        //Ruta del fichero donde se van a guardar las notas.
        private String nombreFichero = "shirunotes.txt";

        //---------

        //Creamos un List para guardar los objetos de tipo ObjetoNota que contendran
        //el titulo y el contenido.
        private List<ObjetoNota> Notas = new List<ObjetoNota>();

        //Creo el objeto nota para trabajar con él pero
        //no lo inizializo
        private ObjetoNota nota;

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
                //No guarda
                MessageBox.Show("No has insertado titulo");
            }
            else if (tituloNotaActual.Contains("$") || tituloNotaActual.Contains("/") || tituloNotaActual.Contains("*"))
            {
                //No guardar
                MessageBox.Show("El titulo insertado contiene caracteres invalidos ej. $, /, *");
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
                //guardar en nota ya creada (sobreescribir)
                sobreEscribir(tituloNotaActual, contenidoNotaActual, pos);
            }
            else
            {
                //crea nota y la guarda
                nota = new ObjetoNota(tituloNotaActual, contenidoNotaActual);
                Notas.Add(nota);
                AnyadirItemsCB(tituloNotaActual);
                GuardarNota(tituloNotaActual, contenidoNotaActual);
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
                BorrarItemsFichero(Notas[i].Titulo);
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

        //Funcion para sobreescribir un fichero.
        private void sobreEscribir(String tituloNotaActual, String contenidoNotaActual, int pos)
        {
            Notas[pos].SetNota(tituloNotaActual, contenidoNotaActual);
            replaceString(tituloNotaActual, contenidoNotaActual);
            MessageBox.Show("Sobreescrito nota existente con titulo: " + tituloNotaActual);
            ClearContenidos();
        }

        //funcion para guardar nuevas notas en el programa, no el fichero.
        private void guardarNuevaNota(String tituloNotaActual, String contenidoNotaActual)
        {
            nota = new ObjetoNota(tituloNotaActual, contenidoNotaActual);
            Notas.Add(nota);
            AnyadirItemsCB(tituloNotaActual);
        }

        //Funciones de fichero ------------------------------------------

        //Funcion para guardar texto en el fichero en el formato local
        //para poder volver a leerlo luego.
        private void GuardarNota(String titulo, String contenido)
        {
            //fichero = File.AppendText(nombreFichero+".txt");

            StreamWriter sw;

            sw = File.AppendText(nombreFichero);

            sw.WriteLine(titulo + SEPARADOR + contenido + FINFICHERO);

            sw.Close();
        }

        //Esta funcion borra las notas del fichero. Lo hace separando cada nota
        //y luego separando cada titulo de su contenido, comprueba el titulo
        //y si coincide con el titulo enviado borrara la nota del primer array.
        //Al finalizar la vuelta escribe en el fichero.
        private void BorrarItemsFichero(String titulo)
        {
            StreamReader sr = new StreamReader(nombreFichero);
            String[] lineas = Regex.Split(sr.ReadToEnd(), FINFICHERO);
            sr.Close();

            StreamWriter sw = new StreamWriter(nombreFichero);
            for (int i = 0; i < lineas.Length; i++)
            {
                String[] fila = lineas[i].Split(new char[] { SEPARADOR }, 2);
                if (fila[0].Equals(titulo))
                {
                    lineas[i] = String.Empty;
                }
                else if (!string.IsNullOrWhiteSpace(lineas[i]))
                {
                    lineas[i] += FINFICHERO;
                }
                if (!string.IsNullOrWhiteSpace(lineas[i]))
                {
                    sw.WriteLine(lineas[i]);
                }
            }
            sw.Close();
        }

        //Funcion que reeplaza el contenido de las notas en un fichero
        //Funciona separando las filas del archivo en un array y luego comprueba
        //por fila si coincide el titulo que se le pasa. Si es asi
        //separa el titulo del contenido y luego reeplaza el contenido
        //antiguo con el nuevo
        private void replaceString(String titulo, String reemplazar)
        {
            reemplazar += FINFICHERO;
            StreamReader sr = new StreamReader(nombreFichero);
            String[] lineas = Regex.Split(sr.ReadToEnd(), FINFICHERO);
            sr.Close();

            StreamWriter sw = new StreamWriter(nombreFichero);
            for (int i = 0; i < lineas.Length; i++)
            {
                if (lineas[i].Contains(titulo))
                {
                    String[] fila = lineas[i].Split(new char[] { SEPARADOR }, 2);
                    lineas[i] = lineas[i].Replace(fila[1], reemplazar);
                }
                else if (!string.IsNullOrWhiteSpace(lineas[i]))
                {
                    lineas[i] += FINFICHERO;
                }
                if (!string.IsNullOrWhiteSpace(lineas[i]))
                {
                    sw.WriteLine(lineas[i]);
                }
            }
            sw.Close();
        }

        //Esta funcion se ejecuta al iniciar el programa para cargar las notas
        //guardadas en el fichero local. Si no hay ningun fichero ejecutara el programa directamente
        private void CargarFichero()
        {
            String[] lineas = null;

            try
            {
                StreamReader sr = new StreamReader(nombreFichero);
                lineas = Regex.Split(sr.ReadToEnd(), FINFICHERO);
                sr.Close();

                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    if (lineas[i] != String.Empty)
                    {
                        String[] fila = lineas[i].Split(new char[] { SEPARADOR }, 2);
                        guardarNuevaNota(fila[0], fila[1]);
                    }
                }
            }
            catch
            {
            }
        }
    }
}