#pragma checksum "C:\Users\aleja\Desktop\Proyecto_UWP\Proyecto_UWP\cuVisualizador.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6E361987E5375551EC1A357B71E6FD48"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_UWP
{
    partial class cuVisualizador : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // cuVisualizador.xaml line 1
                {
                    this.userControl = (global::Windows.UI.Xaml.Controls.UserControl)(target);
                    ((global::Windows.UI.Xaml.Controls.UserControl)this.userControl).PointerEntered += this.punteroDentro;
                    ((global::Windows.UI.Xaml.Controls.UserControl)this.userControl).PointerExited += this.punteroFuera;
                }
                break;
            case 2: // cuVisualizador.xaml line 12
                {
                    this.sbZoomIn = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 3: // cuVisualizador.xaml line 21
                {
                    this.sbFav = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 4: // cuVisualizador.xaml line 112
                {
                    this.sbZoomOut = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 5: // cuVisualizador.xaml line 123
                {
                    this.grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6: // cuVisualizador.xaml line 132
                {
                    this.btnInfo = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)this.btnInfo).PointerReleased += this.cargarInfo;
                }
                break;
            case 7: // cuVisualizador.xaml line 134
                {
                    this.imgAñadir = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)this.imgAñadir).PointerReleased += this.btnAñadir_Click;
                }
                break;
            case 8: // cuVisualizador.xaml line 135
                {
                    this.tbTitulo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // cuVisualizador.xaml line 136
                {
                    this.imgPelicula = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 10: // cuVisualizador.xaml line 137
                {
                    this.imgReproducir = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)this.imgReproducir).PointerReleased += this.cargarVideo;
                }
                break;
            case 11: // cuVisualizador.xaml line 138
                {
                    this.path = (global::Windows.UI.Xaml.Shapes.Path)(target);
                }
                break;
            case 12: // cuVisualizador.xaml line 143
                {
                    this.path1 = (global::Windows.UI.Xaml.Shapes.Path)(target);
                }
                break;
            case 13: // cuVisualizador.xaml line 148
                {
                    this.path2 = (global::Windows.UI.Xaml.Shapes.Path)(target);
                }
                break;
            case 14: // cuVisualizador.xaml line 153
                {
                    this.path3 = (global::Windows.UI.Xaml.Shapes.Path)(target);
                }
                break;
            case 15: // cuVisualizador.xaml line 158
                {
                    this.path4 = (global::Windows.UI.Xaml.Shapes.Path)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

