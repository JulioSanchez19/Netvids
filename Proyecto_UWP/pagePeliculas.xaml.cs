using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Proyecto_UWP
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class pagePeliculas : Page
    {
        private MainPage mp;
        private ArrayList peliculas = new ArrayList();
        public pagePeliculas()
        {
            this.InitializeComponent();
            quitarSombreado();

            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(320, 370));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += PagePeliculas_VisibleBoundsChanged;

            //inicializarPeliculas();
        }

        private void vis1_Loaded(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(reproductor));
        }

        public bool openedPane
        {
            get { return svMenu.IsPaneOpen; }
            set { svMenu.IsPaneOpen=value; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                //mp = (MainPage)e.Parameter;

                object[] menus = (object[])e.Parameter;
                
                if ((bool)menus[1] == true && (bool)menus[0] == true)
                {
                    svMenu.IsPaneOpen = true;
                }
                else if ((bool)menus[1] == true && (bool)menus[0] == false)
                {
                    svMenu.IsPaneOpen = false;
                }
                else
                {
                    svMenu.IsPaneOpen = (bool)menus[1];
                }
                mp = (MainPage)menus[2];

                peliculas = (ArrayList)menus[4];

                foreach (Pelicula serie in peliculas)
                {
                    cuVisualizador vis = new cuVisualizador();
                    vis.tituloPelicula = serie.titulo;
                    vis.descripcionPelicula = serie.descripcion;
                    vis.directorPelicula = serie.director;
                    vis.actorPrincipalPelicula = serie.actorPrincipal;
                    vis.imagenPelicula = serie.imagen;
                    vis.frame = this.Frame;
                    vis.numCapitulosSerie = serie.duracion;
                    vis.mainPage = mp;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    vis.Visibility = Visibility.Visible;
                    vsgPeliculas.Children.Add(vis);
                }


            }           
        }

        private void btnRomance_Click(object sender, RoutedEventArgs e)
        {
            quitarSombreado();
            btnRomance.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            int length = vsgPeliculas.Children.Count;
            for (int i = 0; i < length; i++)
            {
                vsgPeliculas.Children.RemoveAt(0);
            }

            foreach (Pelicula peli in peliculas)
            {
                if (peli.tipo.Equals("Romance"))
                {
                    cuVisualizador vis = new cuVisualizador();
                    vis.tituloPelicula = peli.titulo;
                    vis.descripcionPelicula = peli.descripcion;
                    vis.directorPelicula = peli.director;
                    vis.actorPrincipalPelicula = peli.actorPrincipal;
                    vis.imagenPelicula = peli.imagen;
                    vis.frame = this.Frame;
                    vis.duracionPelicula = peli.duracion;
                    vis.mainPage = mp;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    vis.Visibility = Visibility.Visible;
                    vsgPeliculas.Children.Add(vis);
                }
            }
        }

        private void btnComedia_Click(object sender, RoutedEventArgs e)
        {
            quitarSombreado();
            btnComedia.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            int length = vsgPeliculas.Children.Count;
            for (int i = 0; i < length; i++)
            {
                vsgPeliculas.Children.RemoveAt(0);
            }

            foreach (Pelicula peli in peliculas)
            {
                if (peli.tipo.Equals("Comedia"))
                {
                    cuVisualizador vis = new cuVisualizador();
                    vis.tituloPelicula = peli.titulo;
                    vis.descripcionPelicula = peli.descripcion;
                    vis.directorPelicula = peli.director;
                    vis.actorPrincipalPelicula = peli.actorPrincipal;
                    vis.imagenPelicula = peli.imagen;
                    vis.frame = this.Frame;
                    vis.duracionPelicula = peli.duracion;
                    vis.mainPage = mp;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    vis.Visibility = Visibility.Visible;
                    vsgPeliculas.Children.Add(vis);
                }
            }
        }

        private void btnTerror_Click(object sender, RoutedEventArgs e)
        {
            quitarSombreado();
            btnTerror.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            int length = vsgPeliculas.Children.Count;
            for (int i = 0; i < length; i++)
            {
                vsgPeliculas.Children.RemoveAt(0);
            }

            foreach (Pelicula peli in peliculas)
            {
                if (peli.tipo.Equals("Terror"))
                {
                    cuVisualizador vis = new cuVisualizador();
                    vis.tituloPelicula = peli.titulo;
                    vis.descripcionPelicula = peli.descripcion;
                    vis.directorPelicula = peli.director;
                    vis.actorPrincipalPelicula = peli.actorPrincipal;
                    vis.imagenPelicula = peli.imagen;
                    vis.frame = this.Frame;
                    vis.duracionPelicula = peli.duracion;
                    vis.mainPage = mp;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    vis.Visibility = Visibility.Visible;
                    vsgPeliculas.Children.Add(vis);
                }
            }
        }

        private void PagePeliculas_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;

            if (Width >= 720)
            {
                svMenu.IsPaneOpen = true;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactInline;
            }
            else if (Width >= 360)
            {
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            }
            else
            {
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.Overlay;
            }
        }

        private void quitarSombreado()
        {
            btnRomance.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
            btnTerror.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
            btnComedia.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104)); new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
        }

        private void inicializarPeliculas()
        {
            XmlDocument doc = new XmlDocument();
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            doc.Load(local.Path + "/persistencia.xml");
            Debug.WriteLine(local.Path + "/persistencia.xml");
            foreach (XmlNode nodo in doc.DocumentElement.ChildNodes[0].ChildNodes)
            {
                Pelicula p = new Pelicula(nodo.Attributes["titulo"].Value, nodo.Attributes["descripcion"].Value, nodo.Attributes["actorPrincipal"].Value, nodo.Attributes["director"].Value, Convert.ToInt32(nodo.Attributes["duracion"].Value), nodo.Attributes["tipo"].Value, new BitmapImage(new Uri(nodo.Attributes["imagen"].Value)), Convert.ToBoolean(nodo.Attributes["favorito"].Value), Convert.ToBoolean(nodo.Attributes["visto"].Value));

                peliculas.Add(p);

                cuVisualizador vis = new cuVisualizador();
                vis.tituloPelicula = p.titulo;
                vis.descripcionPelicula = p.descripcion;
                vis.directorPelicula = p.director;
                vis.actorPrincipalPelicula = p.actorPrincipal;
                vis.imagenPelicula = p.imagen;
                vis.frame = this.Frame;
                vis.duracionPelicula = p.duracion;
                vis.mainPage = mp;
                vis.Visibility = Visibility.Visible;
                vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                vsgPeliculas.Children.Add(vis);
            }
        }
    }
}
