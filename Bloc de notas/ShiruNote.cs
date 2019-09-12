using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bloc_de_notas
{
    public partial class ShiruNote : Form
    {
        public ShiruNote()
        {
            InitializeComponent();
            //version
            this.Text = "ShiruNote " + "0.8.1";
            //CargarFichero();
            CargarBD();
        }

        //--------
        //config (CAMBIAR ESTO PUEDE ROMPER ARCHIVOS YA EXISTENTES)
        //private String FINFICHERO = "<END>";

        //private char SEPARADOR = '$';

        ////Ruta del fichero donde se van a guardar las notas.
        //private String nombreFichero = "shirunotes.txt";

        //---------

        private MySqlConnection conexion;

        private String dbserver = "192.168.1.140";
        private String dbuser = "shiruPC2";
        private String dbpass = "";
        private String db = "notasvisual";

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
                UpdateBD(tituloNotaActual, contenidoNotaActual);
            }
            else
            {
                //crea nota y la guarda
                nota = new ObjetoNota(tituloNotaActual, contenidoNotaActual);
                Notas.Add(nota);
                AnyadirItemsCB(tituloNotaActual);
                //GuardarNota(tituloNotaActual, contenidoNotaActual);
                InsertarBD(tituloNotaActual, contenidoNotaActual);
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
                BorrarNotaBD(Notas[i].Titulo);
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
            //replaceString(tituloNotaActual, contenidoNotaActual);
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

        //Esta funcion inserta notas en la base de datos. Inserta el titulo como clave primaria y el contenido en un longtext.
        private void InsertarBD(String titulo, String contenido)
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

                builder.Server = dbserver;
                builder.UserID = dbuser;
                builder.Password = dbpass;
                builder.Database = db;

                conexion = new MySqlConnection(builder.ToString());

                String consulta = "insert into notas(titulo, contenido) values(?titulo, ?contenido);";

                conexion.Open();

                MySqlCommand cmd = new MySqlCommand(consulta, conexion);

                cmd.Parameters.AddWithValue("?contenido", contenido);
                cmd.Parameters.AddWithValue("?titulo", titulo);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Insertado correctamente");
                conexion.Close();

                ClearContenidos();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al insertar datos en la base de datos! " + e.Message);
            }
        }

        //Esta funcion carga los datos de la base de datos al array del programa para listarlas. Si no existe la base de datos o da algun error,
        //intentara crear la base de datos. Si no lo consigue cerrara el programa.
        private void CargarBD()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

                builder.Server = dbserver;
                builder.UserID = dbuser;
                builder.Password = dbpass;
                builder.Database = db;

                conexion = new MySqlConnection(builder.ToString());

                String consulta = "select * from notas";

                conexion.Open();

                MySqlCommand cmd = new MySqlCommand(consulta, conexion);

                MySqlDataReader rs = cmd.ExecuteReader();

                while (rs.Read())
                {
                    guardarNuevaNota(rs.GetString(0), rs.GetString(1));
                }

                rs.Close();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al iniciar datos BD! " + e.Message + " intentando crear base de datos y tabla...");
                CrearBD();
            }
        }

        //Esta funcion se llama cuando se intenta guardar una nota que ya existe, y la sobreescribe. Esa comprobacion se hace con el array del programa
        //y esta funcion solo ejecuta la consulta update con la nueva informacion.
        private void UpdateBD(String titulo, String contenido)
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

                builder.Server = dbserver;
                builder.UserID = dbuser;
                builder.Password = dbpass;
                builder.Database = db;

                conexion = new MySqlConnection(builder.ToString());

                String consulta = "update notas" +
                    " set contenido = ?nota where titulo = ?titulo";

                conexion.Open();

                MySqlCommand cmd = new MySqlCommand(consulta, conexion);

                cmd.Parameters.AddWithValue("?titulo", titulo);
                cmd.Parameters.AddWithValue("?nota", contenido);

                cmd.ExecuteNonQuery();

                MessageBox.Show("sobreescrito correctamente");
                conexion.Close();

                ClearContenidos();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al sobreescribir datos en la base de datos! " + e.Message);
            }
        }

        //Esta funcion envia la consulta de borrar una nota de la base de datos dado un titulo.
        private void BorrarNotaBD(String titulo)
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

                builder.Server = dbserver;
                builder.UserID = dbuser;
                builder.Password = dbpass;
                builder.Database = db;

                conexion = new MySqlConnection(builder.ToString());

                String consulta = "delete from notas where titulo = ?titulo";

                conexion.Open();

                MySqlCommand cmd = new MySqlCommand(consulta, conexion);

                cmd.Parameters.AddWithValue("?titulo", titulo);

                cmd.ExecuteNonQuery();

                MessageBox.Show("eliminado correctamente");
                conexion.Close();

                ClearContenidos();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al eliminar datos en la base de datos! " + e.Message);
            }
        }

        private void CrearBD()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

                builder.Server = dbserver;
                builder.UserID = dbuser;
                builder.Password = dbpass;

                conexion = new MySqlConnection(builder.ToString());

                String consulta = "create database notasvisual; create table notasvisual.notas(titulo varchar(50) primary key, contenido longtext );";

                conexion.Open();

                MySqlCommand cmd = new MySqlCommand(consulta, conexion);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Base de datos y tabla creadas con exito correctamente");
                conexion.Close();

                ClearContenidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la base de datos! " + ex.Message + " Cerrando...");

                System.Environment.Exit(001);
            }
        }
    }
}