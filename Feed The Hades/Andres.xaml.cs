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
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Feed_The_Hades
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Andres : Page
    {

        int SOULS;
        public Andres()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SharedShadow.Receivers.Add(purpleRect);

            soul.Translation += new System.Numerics.Vector3(0, 0, 32);
            //soul.Rotation = 45;

            SOULS = 0;
            soulText.Text = SOULS.ToString() + " ALMAS";

            //Mueves los rectángulos hacia delante 


        }

        private void soul_Click(object sender, RoutedEventArgs e)
        {
            SOULS++;
            soulText.Text = SOULS.ToString() +1000 + " ALMAS";
        }


    }
}
