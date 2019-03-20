using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloc_de_notas
{
    class ObjetoNota
    {
        private String contenido;
        private String titulo;

        public string Contenido { get => contenido; set => contenido = value; }
        public string Titulo { get => titulo; set => titulo = value; }

        public ObjetoNota(string contenido, string titulo)
        {
            this.Contenido = contenido;
            this.Titulo = titulo;
        }

        public ObjetoNota()
        {
        }


    }
}
