using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Proyecto_UWP
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class pageBuscador : Page
    {
        MainPage mp;
        public pageBuscador()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                object[] menus = (object[])e.Parameter;

                /*if ((bool)menus[1] == true && (bool)menus[0] == true)
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
                }*/
                mp = (MainPage)menus[2];
                ArrayList matches = (ArrayList)menus[3];
                Pelicula peliAux = new Pelicula();
                foreach (Object match in matches)
                {
                    cuVisualizador vis = new cuVisualizador();
                    if (match.GetType() == peliAux.GetType())
                    {
                        Pelicula p = (Pelicula)match;
                        vis.tituloPelicula = p.titulo;
                        vis.descripcionPelicula = p.descripcion;
                        vis.directorPelicula = p.director;
                        vis.actorPrincipalPelicula = p.actorPrincipal;
                        vis.imagenPelicula = p.imagen;
                        vis.frame = this.Frame;
                        vis.mainPage = mp;
                        vis.Visibility = Visibility.Visible;
                        vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    }
                    else
                    {
                        Serie s = (Serie)match;
                        vis.tituloPelicula = s.titulo;
                        vis.descripcionPelicula = s.descripcion;
                        vis.directorPelicula = s.director;
                        vis.actorPrincipalPelicula = s.actorPrincipal;
                        vis.imagenPelicula = s.imagen;
                        vis.frame = this.Frame;
                        vis.mainPage = mp;
                        vis.Visibility = Visibility.Visible;
                        vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    }
                    vsgMatches.Children.Add(vis);

                }
                /*foreach (Serie serie in matches)
                {
                    cuVisualizador vis = new cuVisualizador();
                    vis.tituloPelicula = serie.titulo;
                    vis.descripcionPelicula = serie.descripcion;
                    vis.directorPelicula = serie.director;
                    vis.actorPrincipalPelicula = serie.actorPrincipal;
                    vis.imagenPelicula = serie.imagen;
                    vis.frame = this.Frame;
                    vis.mainPage = mp;
                    vis.Visibility = Visibility.Visible;

                    vsgMatches.Children.Add(vis);

                }*/
            }
        }
    }
}
