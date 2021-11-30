using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
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
    public sealed partial class pageInfo : Page
    {
        public pageInfo()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Video v = (Video)e.Parameter;

            if (e.Parameter != null)
            {
                // Create run and set text
                Run run = new Run();
                run.Text = v.descripcion;

                // Create paragraph
                Paragraph paragraph = new Paragraph();

                // Add run to the paragraph
                paragraph.Inlines.Add(run);

                // Add paragraph to the rich text block
                rtbDescripcion.Blocks.Add(paragraph);

                tbTitulo.Text = v.nombre;

                imgPelicula.Source = v.imagen;

                tbActorPrincipal.Text = v.actorPrincipal;

                tbDirector.Text = v.director;

                tbDuracion.Text= v.duracion.ToString() + " min";
            }
        }
    }
}
