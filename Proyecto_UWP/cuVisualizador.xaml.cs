using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Proyecto_UWP
{
    public sealed partial class cuVisualizador : UserControl
    {
        private String descripcion;
        private String director;
        private String actorPrincipal;

        public string tituloPelicula
        {
            get { return tbTitulo.Text; }
            set { tbTitulo.Text = value; }
        }

        public ImageSource imagenPelicula
        {
            get { return imgPelicula.Source; }
            set { imgPelicula.Source = value; }
        }

        public String descripcionPelicula
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String directorPelicula
        {
            get { return director; }
            set { director = value; }
        }

        public String actorPrincipalPelicula
        {
            get { return actorPrincipal; }
            set { actorPrincipal = value; }
        }

        public string enlacePelicula { get; set; }

        private MainPage mp;

        public MainPage mainPage
        {
            get { return mp; }
            set { mp = value; }
        }


        public cuVisualizador()
        {
            this.InitializeComponent();
        }

        private int duracion;

        public int duracionPelicula
        {
            get { return duracion; }
            set { duracion = value; }
        }

        private int numCapitulos;

        public int numCapitulosSerie
        {
            get { return numCapitulos; }
            set { numCapitulos = value; }
        }



        private Frame framePrincipal;
        private string contents;

        public Frame frame
        {
            get { return framePrincipal; }
            set { framePrincipal = value; }
        }
        private void cargarInfo(object sender, RoutedEventArgs e)
        {
            Video p = new Video
            {
                nombre = tituloPelicula,
                imagen = imagenPelicula,
                descripcion = descripcionPelicula,
                director = directorPelicula,
                actorPrincipal = actorPrincipalPelicula,
                duracion = duracionPelicula

            };
            //MainPage mp = new MainPage();
            mp.cambiarFrameConInfo(typeof(pageInfo),  p);
        }
               
        private void punteroDentro(object sender, PointerRoutedEventArgs e)
        {
            Storyboard animacion = (Storyboard)this.Resources["sbZoomIn"];
            animacion.Begin();
            imgReproducir.Visibility = Visibility.Visible;
            //imgPelicula.Height = 190;
        }

        private void punteroFuera(object sender, PointerRoutedEventArgs e)
        {
            Storyboard animacion = (Storyboard)this.Resources["sbZoomOut"];
            animacion.Begin();
            imgReproducir.Visibility = Visibility.Collapsed;
            //imgPelicula.Height = 145;
        }

        private void cargarVideo(object sender, PointerRoutedEventArgs e)
        {
            mp.cambiarFrame(typeof(reproductor));
            //Obtener contenido XML
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            XmlDocument doc = new XmlDocument();
            using (StreamReader streamReader = new StreamReader(local.Path + "/persistencia.xml", Encoding.UTF8))
            {
                contents = streamReader.ReadToEnd();
            }
            doc.LoadXml(contents);

            //Peliculas
            foreach (XmlNode nodo in doc.DocumentElement.ChildNodes[0].ChildNodes)
            {
                if (nodo.Attributes["titulo"].Value.Equals(tituloPelicula))
                {
                    nodo.Attributes["visto"].Value = true.ToString();
                    break;
                }
            }

            //Series
            foreach (XmlNode nodo in doc.DocumentElement.ChildNodes[1].ChildNodes)
            {
                if (nodo.Attributes["titulo"].Value.Equals(tituloPelicula))
                {
                    nodo.Attributes["visto"].Value = true.ToString();
                    break;
                }
            }
            //Actualizar XML
            using (FileStream fs = new FileStream(local.Path + "/persistencia.xml", FileMode.Create))
            {
                doc.Save(fs);
            }

            cargarTiles();

        }

        public void cargarTiles()
        {
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Branding = TileBranding.Name,
                        DisplayName = "NetVids",
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
                                    Text = "Continuar viendo:\n "+tituloPelicula,
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
                                    Text = "Acceda a NetVids para disfrutar\nde todas las peliculas y series de \nla actualidad, podra ver +2000\n titulos",
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

        private void btnAñadir_Click(object sender, PointerRoutedEventArgs e)
        {
            imgAñadir.Source = new BitmapImage(new Uri("ms-appx:///Images/star.png"));
            Storyboard animacion = (Storyboard)this.Resources["sbFav"];
            animacion.Begin();

            //Obtener contenido XML
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            XmlDocument doc = new XmlDocument();
            using (StreamReader streamReader = new StreamReader(local.Path + "/persistencia.xml", Encoding.UTF8))
            {
                contents = streamReader.ReadToEnd();
            }
            doc.LoadXml(contents);

            //Peliculas
            foreach (XmlNode nodo in doc.DocumentElement.ChildNodes[0].ChildNodes)
            {
                if (nodo.Attributes["titulo"].Value.Equals(tituloPelicula))
                {
                    bool fav = false;
                    String isFav = nodo.Attributes["favorito"].Value;
                    if (isFav == "true") fav = true;
                    nodo.Attributes["favorito"].Value = (!fav).ToString();
                    break;
                }
            }

            //Series
            foreach (XmlNode nodo in doc.DocumentElement.ChildNodes[1].ChildNodes)
            {
                if (nodo.Attributes["titulo"].Value.Equals(tituloPelicula))
                {
                    bool fav = false;
                    String isFav = nodo.Attributes["favorito"].Value;
                    if (isFav == "true") fav = true;
                    nodo.Attributes["favorito"].Value = (!fav).ToString();
                    break;
                }
            }
            //Actualizar XML
            using (FileStream fs = new FileStream(local.Path + "/persistencia.xml", FileMode.Create))
            {
                doc.Save(fs);
            }



            new ToastContentBuilder()
            .AddArgument("action", "Favoritos")
            .AddArgument("conversationId", 9813)
            .AddText(tituloPelicula + " marcado como Favorito")
            .AddText("Puedes ver más información en NetVids")
            //.AddInlineImage(new Uri(enlacePelicula))
            .AddAppLogoOverride(new Uri("ms-appx:///Images/logoNBlueBlack.png"), ToastGenericAppLogoCrop.Default)
            .Show();
        }

        public async System.Threading.Tasks.Task cargarXMLAsync()
        {
            StorageFile file = await Package.Current.InstalledLocation.GetFileAsync("Persistencia.xml");
            using (IRandomAccessStream writeStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                System.IO.Stream s = writeStream.AsStreamForWrite();
                System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
                settings.Async = true;
                using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(s, settings))
                {


                    writer.WriteStartElement("Pelicula");
                    writer.WriteElementString("favorito", "true");

                    writer.Flush();


                    await writer.FlushAsync();
                }
            }
        }
        /*public static MainPage GetMainPage()
{
MainPage mainPage = null;

foreach (Page window in Application.Current.Resources.)
{
Type type = typeof(MainPage);
if (window != null && window.DependencyObjectType.Name == type.Name)
{
  mainPage = (MainPage)window;
  if (mainPage != null)
  {
      break;
  }
}
}


return mainPage;

}*/
    }
}
