using System;

namespace Bloc_de_notas
{
    internal class ObjetoNota
    {
        private String contenido;
        private String titulo;

        public string Contenido { get => contenido; set => contenido = value; }
        public string Titulo { get => titulo; set => titulo = value; }

        public ObjetoNota(string titulo, string contenido)
        {
            this.Contenido = contenido;
            this.Titulo = titulo;
        }

        public ObjetoNota()
        {
        }

        public void SetNota(String titulo, String texto) {

            this.titulo = titulo;
            this.contenido = texto;

        }


    }
}