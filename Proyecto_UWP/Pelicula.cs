using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Proyecto_UWP
{
    class Pelicula
    {
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string actorPrincipal { get; set; }
        public string director { get; set; }
        public int duracion { get; set; }
        public string tipo { get; set; }
        public BitmapImage imagen { get; set; }
        public bool favorito { get; set; }
        public bool visto { get; set; }

        public Pelicula()
        {

        }

        public Pelicula(string titulo, string descripcion, string actorPrincipal, string director, int duracion, string tipo, BitmapImage imagen, bool favorito, bool visto)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.actorPrincipal = actorPrincipal;
            this.director = director;
            this.duracion = duracion;
            this.imagen = imagen;
            this.tipo = tipo;
            this.favorito = favorito;
            this.visto = visto;
        }
    }
}
