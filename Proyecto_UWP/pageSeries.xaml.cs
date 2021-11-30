using System;
using System.Collections;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Proyecto_UWP
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class pageSeries : Page
    {
        ArrayList series = new ArrayList();
        MainPage mp;
        public pageSeries()
        {
            this.InitializeComponent();
            quitarSombreado();

            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(320, 370));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += PageSeries_VisibleBoundsChanged;

            //inicializarSeries();
        }

        private void PageSeries_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {

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

                series = (ArrayList)menus[5];

                foreach (Serie serie in series)
                {
                    cuVisualizador vis = new cuVisualizador();
                    vis.tituloPelicula = serie.titulo;
                    vis.descripcionPelicula = serie.descripcion;
                    vis.directorPelicula = serie.director;
                    vis.actorPrincipalPelicula = serie.actorPrincipal;
                    vis.imagenPelicula = serie.imagen;
                    vis.frame = this.Frame;
                    vis.numCapitulosSerie = serie.numCapitulos;
                    vis.mainPage = mp;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    vis.Visibility = Visibility.Visible;
                    vsgSeries.Children.Add(vis);
                }
            }
        }
        private void btnEpico_Click(object sender, RoutedEventArgs e)
        {
            quitarSombreado();
            btnEpico.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            int length = vsgSeries.Children.Count;
            for (int i = 0; i < length; i++)
            {
                vsgSeries.Children.RemoveAt(0);
            }

            foreach (Serie serie in series)
            {
                if (serie.tipo.Equals("Epico"))
                {
                    cuVisualizador vis = new cuVisualizador();
                    vis.tituloPelicula = serie.titulo;
                    vis.descripcionPelicula = serie.descripcion;
                    vis.directorPelicula = serie.director;
                    vis.actorPrincipalPelicula = serie.actorPrincipal;
                    vis.imagenPelicula = serie.imagen;
                    vis.frame = this.Frame;
                    vis.numCapitulosSerie = serie.numCapitulos;
                    vis.mainPage = mp;
                    vis.Visibility = Visibility.Visible;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    vsgSeries.Children.Add(vis);
                }
            }
        }

        private void btnDrama_Click(object sender, RoutedEventArgs e)
        {
            quitarSombreado();
            btnDrama.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            int length = vsgSeries.Children.Count;
            for (int i = 0; i < length; i++)
            {
                vsgSeries.Children.RemoveAt(0);
            }

            foreach (Serie serie in series)
            {
                if (serie.tipo.Equals("Drama"))
                {
                    cuVisualizador vis = new cuVisualizador();
                    vis.tituloPelicula = serie.titulo;
                    vis.descripcionPelicula = serie.descripcion;
                    vis.directorPelicula = serie.director;
                    vis.actorPrincipalPelicula = serie.actorPrincipal;
                    vis.imagenPelicula = serie.imagen;
                    vis.frame = this.Frame;
                    vis.numCapitulosSerie = serie.numCapitulos;
                    vis.mainPage = mp;
                    vis.Visibility = Visibility.Visible;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    vsgSeries.Children.Add(vis);
                }
            }
        }

        private void btnThriller_Click(object sender, RoutedEventArgs e)
        {
            quitarSombreado();
            btnThriller.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            int length = vsgSeries.Children.Count;
            for (int i = 0; i < length; i++)
            {
                vsgSeries.Children.RemoveAt(0);
            }

            foreach (Serie serie in series)
            {
                if (serie.tipo.Equals("Thriller"))
                {
                    cuVisualizador vis = new cuVisualizador();
                    vis.tituloPelicula = serie.titulo;
                    vis.descripcionPelicula = serie.descripcion;
                    vis.directorPelicula = serie.director;
                    vis.actorPrincipalPelicula = serie.actorPrincipal;
                    vis.imagenPelicula = serie.imagen;
                    vis.frame = this.Frame;
                    vis.numCapitulosSerie = serie.numCapitulos;
                    vis.mainPage = mp;
                    vis.Visibility = Visibility.Visible;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    vsgSeries.Children.Add(vis);
                }
            }
        }

        private void quitarSombreado()
        {
            btnThriller.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
            btnDrama.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
            btnEpico.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
        }

        private void inicializarSeries()
        {
            XmlDocument doc = new XmlDocument();
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            doc.Load(local.Path + "/persistencia.xml");

            foreach (XmlNode nodo in doc.DocumentElement.ChildNodes[1].ChildNodes)
            {
                Serie s = new Serie(nodo.Attributes["titulo"].Value, nodo.Attributes["descripcion"].Value, nodo.Attributes["actorPrincipal"].Value, nodo.Attributes["director"].Value, Convert.ToInt32(nodo.Attributes["numCapitulos"].Value), nodo.Attributes["tipo"].Value, new BitmapImage(new Uri(nodo.Attributes["imagen"].Value)), Convert.ToBoolean(nodo.Attributes["favorito"].Value), Convert.ToBoolean(nodo.Attributes["visto"].Value));

                series.Add(s);

                cuVisualizador vis = new cuVisualizador();
                vis.tituloPelicula = s.titulo;
                vis.descripcionPelicula = s.descripcion;
                vis.directorPelicula = s.director;
                vis.actorPrincipalPelicula = s.actorPrincipal;
                vis.imagenPelicula = s.imagen;
                vis.frame = this.Frame;
                vis.numCapitulosSerie = s.numCapitulos;
                vis.mainPage = mp;
                vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                vis.Visibility = Visibility.Visible;
                vsgSeries.Children.Add(vis);
            }
        }
    }
}
