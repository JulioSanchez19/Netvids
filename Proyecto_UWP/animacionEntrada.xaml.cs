using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Proyecto_UWP
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class animacionEntrada : Page
    {
        Storyboard animacion;
        string usuario;
        public animacionEntrada()
        {
            this.InitializeComponent();
            //Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(2500, 2500));
            //Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
            //ApplicationView.GetForCurrentView().TryResizeView(new Size(1360, 768));
            //Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.Maximized;


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                usuario = (String)e.Parameter;
                animacion = (Storyboard)this.Resources["animacionSplashScreen"];
                //animacion.Completed += (o, s) => { MainPage mp = new MainPage(); };
                animacion.Completed += (o, s) => { this.Frame.Navigate(typeof(MainPage), usuario); };
                animacion.Begin();
            }
        }
    }
}
