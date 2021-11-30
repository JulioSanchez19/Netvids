using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Proyecto_UWP
{
    class Serie
    {
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string actorPrincipal { get; set; }
        public string director { get; set; }
        public int numCapitulos { get; set; }
        public string tipo { get; set; }
        public BitmapImage imagen { get; set; }
        public bool favorito { get; set; }
        public bool visto { get; set; }

        public Serie(string titulo, string descripcion, string actorPrincipal, string director, int numCapitulos, string tipo, BitmapImage imagen, bool favorito, bool visto)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.actorPrincipal = actorPrincipal;
            this.director = director;
            this.numCapitulos = numCapitulos;
            this.tipo = tipo;
            this.imagen = imagen;
            this.favorito = favorito;
            this.visto = visto;
        }
    }
}
