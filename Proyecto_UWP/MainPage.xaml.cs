using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Proyecto_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //bool[] menusAbiertos = new Boolean[2] { false, true }; //primera posicion click menu MainPage, segunda posicion isOpen menu mainPage
        
        object[] menusAbiertos = new object[6] { false, true, null, null, null, null };

        Type paginaAbierta;
        bool peliculasAbierta = false;
        bool seriesAbierta = false;
        private ArrayList peliculas = new ArrayList();
        private ArrayList series = new ArrayList();
        string usuario;
        public MainPage()
        {
            this.InitializeComponent();
            menusAbiertos[2] = this;
            Window.Current.Content = this;
            Window.Current.Activate();

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += irAtras;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(320, 420));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;

            rInicio.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            /*var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("ms-appx:///Images/inicio.png"));
            siInicio.Background = brush;*/
            btnInicio.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));

            crearArchivo();
            inicializarPeliculas();
            inicializarSeries();
            cargarVistos();
            cargarFavoritos();
            cargarNovedades();

            menusAbiertos[4] = peliculas;
            menusAbiertos[5] = series;

            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Branding = TileBranding.Name,
                        DisplayName="NetVids",
                        Content = new TileBindingContentAdaptive()
                        {
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = "Images/peakyBlinders150.jpg"
                            },
                            Children =
                            {
                                /*new AdaptiveText()
                                {
                                    Text = "NetVids",
                                    HintStyle = AdaptiveTextStyle.Subtitle,
                                    //HintAlign=AdaptiveTextAlign.
                                    
                                },*/
                                new AdaptiveText()
                                {
                                    Text = "Novedades",
                                    HintStyle = AdaptiveTextStyle.Caption,
                                    HintWrap=true
                                },
                            }
                        }
                    },
                    TileWide = new TileBinding()
                    {
                        Branding = TileBranding.Name,
                        DisplayName = "NetVids",
                        Content = new TileBindingContentAdaptive()
                        {
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = "Images/logoNBlueBlack.png"
                            },
                            Children =
                            {
                                /*new AdaptiveText()
                                {
                                    Text = "Bienvenido a \nNetVids",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },*/
                                new AdaptiveText()
                                {
                                    Text = "Clicka aquí para conocer todas \nlas novedades",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                                /*new AdaptiveText()
                                {
                                    Text = "Holaaa",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }*/
                            }
                        }
                    },
                    TileLarge = new TileBinding()
                    {
                        Branding = TileBranding.Name,
                        DisplayName = "NetVids",
                        Content = new TileBindingContentAdaptive()
                        {
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = "Images/logoNBlueBlack.png"
                            },
                            Children =
                            {
                                /*new AdaptiveText()
                                {
                                    Text = "Bienvenido a \nNetVids",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },*/
                                new AdaptiveText()
                                {
                                    Text = "Clicka aquí para conocer todas \nlas novedades sobre las peliculas\n y series de la actualidad",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                                /*new AdaptiveText()
                                {
                                    Text = "Hola",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }*/
                            }
                        }
                    },
                }
            };
            var notification = new TileNotification(content.GetXml());
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(600);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(notification);

        }

        private void cargarNovedades()
        {
            viNovedades1.tituloPelicula = "Uno de los nuestros";
            viNovedades1.descripcionPelicula = "Henry Hill, hijo de padre irlandés y madre siciliana, vive en Brooklyn y se siente fascinado por la vida que llevan los gángsters de su barrio, donde la mayoría de los vecinos son inmigrantes. Paul Cicero, el patriarca de la familia Pauline, es el protector del barrio. A los trece años, Henry decide abandonar la escuela y entrar a formar parte de la organización mafiosa como chico de los recados; muy pronto se gana la confianza de sus jefes, gracias a lo cual irá subiendo de categoría";
            viNovedades1.directorPelicula = "Robert de Niro";
            viNovedades1.actorPrincipalPelicula = "Martin Scorsese";
            viNovedades1.imagenPelicula = new BitmapImage(new Uri("https://pics.filmaffinity.com/Uno_de_los_nuestros-657659084-large.jpg"));
            viNovedades1.frame = this.Frame;
            viNovedades1.duracionPelicula = 148;
            viNovedades1.mainPage = this;
            viNovedades1.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
            viNovedades1.Visibility = Visibility.Visible;

            viNovedades2.tituloPelicula = "Peaky Blinders";
            viNovedades2.descripcionPelicula = "Narra la historia de la familia gitana Shelby y su banda de gángsters, un grupo de personas características por sus boinas con cuchillas y dueñas de los asuntos ilegales, que dominan las apuestas clandestinas y se rigen mediante extorsiones.";
            viNovedades2.directorPelicula = "Steven Knight";
            viNovedades2.actorPrincipalPelicula = "Thomas Shelby";
            viNovedades2.imagenPelicula = new BitmapImage(new Uri("https://images-na.ssl-images-amazon.com/images/I/61vhhzO0NML._AC_.jpg"));
            viNovedades2.frame = this.Frame;
            viNovedades2.numCapitulosSerie = 30;
            viNovedades2.mainPage = this;
            viNovedades2.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
            viNovedades2.Visibility = Visibility.Visible;

            viNovedades3.tituloPelicula = "Vikingos";
            viNovedades3.descripcionPelicula = "Narra las aventuras del héroe Ragnar Lothbrok, de sus hermanos vikingos y su familia, cuando él se subleva para convertirse en el rey de las tribus vikingas. Además de ser un guerrero valiente, Ragnar encarna las tradiciones nórdicas de la devoción a los dioses. Según la leyenda era descendiente directo del dios Odín.";
            viNovedades3.directorPelicula = "Katheryn Winnick";
            viNovedades3.actorPrincipalPelicula = "Travis Fimmel";
            viNovedades3.imagenPelicula = new BitmapImage(new Uri("https://pics.filmaffinity.com/Vikingos_Serie_de_TV-616055151-mmed.jpg"));
            viNovedades3.frame = this.Frame;
            viNovedades3.numCapitulosSerie = 89;
            viNovedades3.mainPage = this;
            viNovedades3.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
            viNovedades3.Visibility = Visibility.Visible;

        }

        private void irAtras(object sender, BackRequestedEventArgs e)
        {
            if (frmPrincipal.BackStack.Any())
            {
                frmPrincipal.GoBack();
            }
        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            svMenu.IsPaneOpen = !svMenu.IsPaneOpen;
            //pagePeliculas p = new pagePeliculas();
            //p.openedPane = !p.openedPane;
            menusAbiertos[1] = svMenu.IsPaneOpen;
            if (paginaAbierta != null)
            {
                abrirCerrarMenu(paginaAbierta);
            }
        }

        private void btnPeliculas_Click(object sender, RoutedEventArgs e)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (seriesAbierta)
            {
                seriesAbierta = false;
                peliculasAbierta = true;
                menusAbiertos[0] = true;
            }
            else
            {
                menusAbiertos[0] = !(bool)menusAbiertos[0];
                peliculasAbierta = !peliculasAbierta;

            }
            quitarSombreado();
            rPeliculas.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            btnPeliculas.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255,165, 191, 222));
            paginaAbierta = typeof(pagePeliculas);
            if (Width < 360)
            {
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            }
            abrirCerrarMenu(paginaAbierta);
        }

        private void quitarSombreado()
        {
            rInicio.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
            btnInicio.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
            rPeliculas.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
            btnPeliculas.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
            rSeries.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
            btnSeries.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
            rPerfil.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
            btnPerfil.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 19, 42, 104));
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(MainPage));
            paginaAbierta = null;
            
            //frmPrincipal.Navigate(typeof(MainPage));
            this.Frame.Navigate(typeof(MainPage));
        }
        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;

            if (Width >= 720)
            {
                stackSeguirViendo.Orientation = Orientation.Horizontal;
                stackNovedades.Orientation = Orientation.Horizontal;
                stackFavoritos.Orientation = Orientation.Horizontal;
                svMenu.IsPaneOpen = true;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactInline;
            }
            else if (Width >= 360)
            {
                //svSeguirViendo.HorizontalScrollMode = ScrollMode.Disabled;
                stackSeguirViendo.Orientation = Orientation.Horizontal;
                stackNovedades.Orientation = Orientation.Horizontal;
                stackFavoritos.Orientation = Orientation.Horizontal;
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            }
            else
            {
                stackSeguirViendo.Orientation = Orientation.Vertical;
                stackNovedades.Orientation = Orientation.Vertical;
                stackFavoritos.Orientation = Orientation.Vertical;
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.Overlay;
            }
        }

        private void btnSeries_Click(object sender, RoutedEventArgs e)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (peliculasAbierta)
            {
                peliculasAbierta = false;
                seriesAbierta = true;
                menusAbiertos[0] = true;
            }
            else
            {
                menusAbiertos[0] = !(bool)menusAbiertos[0];
                seriesAbierta = !seriesAbierta;
            }
            quitarSombreado();
            rSeries.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            btnSeries.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            paginaAbierta = typeof(pageSeries);
            if (Width < 360)
            {
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            }
            abrirCerrarMenu(paginaAbierta);
        }

        public void cambiarFrame(Type frame)
        {
            frmPrincipal.Navigate(frame);
        }

        public void cambiarFrameConInfo(Type frame, Object o)
        {
            frmPrincipal.Navigate(frame, o);
        }

        private void btnPerfil_Click(object sender, RoutedEventArgs e)
        {
            quitarSombreado();
            rPerfil.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            btnPerfil.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 165, 191, 222));
            paginaAbierta = null;
            cambiarFrameConInfo(typeof(pagePerfil), usuario);
        }

        private void abrirCerrarMenu(Type page)
        {
            frmPrincipal.Navigate(page, menusAbiertos, new SuppressNavigationTransitionInfo());
        }

        private void buscador(object sender, RoutedEventArgs e)
        {
            ArrayList matches = new ArrayList();
            foreach(Pelicula peli in peliculas)
            {
                if (peli.titulo.ToLower().Contains(tbBuscador.Text.ToLower()))
                {
                    matches.Add(peli);
                }
            }
            foreach (Serie serie in series)
            {
                if (serie.titulo.ToLower().Contains(tbBuscador.Text.ToLower()))
                {
                    matches.Add(serie);
                }
            }
            menusAbiertos[3] = matches;
            abrirCerrarMenu(typeof(pageBuscador));
        }

        private void crearArchivo()
        {
            XmlDocument docResources = new XmlDocument();
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            //Leer persistencia.xml de Resources para llevarlo a la carpeta de AppData
            String contents;
            using (StreamReader streamReader = new StreamReader("Resources/persistencia.xml", Encoding.UTF8))
            {
                contents = streamReader.ReadToEnd();
                streamReader.Close();
            }

            docResources.LoadXml(contents);


            XmlDocument docAppData = new XmlDocument();

            try
            {
                docAppData.Load(local.Path + "/persistencia.xml"); //comprobar si ya existe en AppData
            }
            catch (FileNotFoundException fn)
            {
                using (FileStream fs = new FileStream(local.Path + "/persistencia.xml", FileMode.Create))
                {
                    docResources.Save(fs);
                    fs.Close();
                }
            }
        }

        private void cargarFavoritos()
        {

            foreach (Pelicula peli in peliculas)
            {
                cuVisualizador vis = new cuVisualizador();
                vis.tituloPelicula = peli.titulo;
                //vis.comprobarFavorito();
                if (peli.favorito == true)
                {
                    vis.descripcionPelicula = peli.descripcion;
                    vis.directorPelicula = peli.director;
                    vis.actorPrincipalPelicula = peli.actorPrincipal;
                    vis.imagenPelicula = peli.imagen;
                    vis.frame = this.Frame;
                    vis.duracionPelicula = peli.duracion;
                    vis.mainPage = this;
                    vis.Visibility = Visibility.Visible;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    stackFavoritos.Children.Add(vis);
                    //cuVisualizador vis2 = (cuVisualizador)stackSeguirViendo.Children.Last();
                    //vis2.comprobarFavorito();
                }
            }

            foreach (Serie serie in series)
            {
                cuVisualizador vis = new cuVisualizador();
                vis.tituloPelicula = serie.titulo;
                //vis.comprobarFavorito();
                if (serie.favorito == true)
                {
                    vis.descripcionPelicula = serie.descripcion;
                    vis.directorPelicula = serie.director;
                    vis.actorPrincipalPelicula = serie.actorPrincipal;
                    vis.imagenPelicula = serie.imagen;
                    vis.frame = this.Frame;
                    vis.numCapitulosSerie = serie.numCapitulos;
                    vis.mainPage = this;
                    vis.Visibility = Visibility.Visible;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    stackFavoritos.Children.Add(vis);
                    
                    //vis2.comprobarFavorito();
                }
            }
        }

        private void cargarVistos()
        {

            foreach (Pelicula peli in peliculas)
            {
                if (peli.visto == true)
                {
                    cuVisualizador vis = new cuVisualizador();
                    vis.tituloPelicula = peli.titulo;
                    vis.descripcionPelicula = peli.descripcion;
                    vis.directorPelicula = peli.director;
                    vis.actorPrincipalPelicula = peli.actorPrincipal;
                    vis.imagenPelicula = peli.imagen;
                    vis.frame = this.Frame;
                    vis.duracionPelicula = peli.duracion;
                    vis.mainPage = this;
                    vis.Visibility = Visibility.Visible;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    stackSeguirViendo.Children.Add(vis);

                }
            }

            foreach (Serie serie in series)
            {
                if (serie.visto == true)
                {
                    cuVisualizador vis = new cuVisualizador();
                    vis.tituloPelicula = serie.titulo;
                    vis.descripcionPelicula = serie.descripcion;
                    vis.directorPelicula = serie.director;
                    vis.actorPrincipalPelicula = serie.actorPrincipal;
                    vis.imagenPelicula = serie.imagen;
                    vis.frame = this.Frame;
                    vis.numCapitulosSerie = serie.numCapitulos;
                    vis.mainPage = this;
                    vis.Visibility = Visibility.Visible;
                    vis.Margin = new Thickness(5.0, 5.0, 5.0, 5.0);
                    stackSeguirViendo.Children.Add(vis);
                }
            }
        }

        private void inicializarPeliculas()
        {

            XmlDocument doc = new XmlDocument();
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            doc.Load(local.Path + "/persistencia.xml");

            Debug.WriteLine(local.Path + "/persistencia.xml");

            foreach (XmlNode nodo in doc.DocumentElement.ChildNodes[0].ChildNodes)
            {
                peliculas.Add(new Pelicula(nodo.Attributes["titulo"].Value, nodo.Attributes["descripcion"].Value, nodo.Attributes["actorPrincipal"].Value, nodo.Attributes["director"].Value, Convert.ToInt32(nodo.Attributes["duracion"].Value), nodo.Attributes["tipo"].Value, new BitmapImage(new Uri(nodo.Attributes["imagen"].Value)), Convert.ToBoolean(nodo.Attributes["favorito"].Value), Convert.ToBoolean(nodo.Attributes["visto"].Value)));
            }
        }
        private void inicializarSeries()
        {
            XmlDocument doc = new XmlDocument();
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            doc.Load(local.Path + "/persistencia.xml");

            foreach (XmlNode nodo in doc.DocumentElement.ChildNodes[1].ChildNodes)
            {
                series.Add(new Serie(nodo.Attributes["titulo"].Value, nodo.Attributes["descripcion"].Value, nodo.Attributes["actorPrincipal"].Value, nodo.Attributes["director"].Value, Convert.ToInt32(nodo.Attributes["numCapitulos"].Value), nodo.Attributes["tipo"].Value, new BitmapImage(new Uri(nodo.Attributes["imagen"].Value)), Convert.ToBoolean(nodo.Attributes["favorito"].Value), Convert.ToBoolean(nodo.Attributes["visto"].Value)));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                usuario = (String)e.Parameter;
            }
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            new ToastContentBuilder()
            .AddArgument("action", "Favoritos")
            .AddArgument("conversationId", 9813)
            .AddText("Sesión cerrada con éxito")
            .AddText("Vuelva pronto")
            .AddAppLogoOverride(new Uri("ms-appx:///Images/logoNBlueBlack.png"), ToastGenericAppLogoCrop.Default)
            .Show();
            Application.Current.Exit();
            
        }
    }

    public class Video
    {
        public string nombre { get; set; }
        public ImageSource imagen { get; set; }
        public string descripcion { get; set; }
        public string director { get; set; }
        public string actorPrincipal { get; set; }
        public int duracion { get; set; }
    }
}
