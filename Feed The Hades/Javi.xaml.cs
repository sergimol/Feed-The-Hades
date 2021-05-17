using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    public sealed partial class Javi : Page
    {
        public Javi()
        {
            this.InitializeComponent();
        }
        //Click play
        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PagPrincipal));
        }
        //Click config
        //private void configButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Page2));
        //}
        //Click exit
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        //Keydown down & up -> Navigation between buttons
        public void Panel_Navigation(object sender, KeyRoutedEventArgs e)
        {
            //Objeto para guardar el cambio de foco 
            DependencyObject candidate = null;

            //Anulo el input de los analogicos
            if (e.OriginalKey == VirtualKey.GamepadLeftThumbstickDown || e.OriginalKey == VirtualKey.GamepadLeftThumbstickUp
                || e.OriginalKey == VirtualKey.GamepadLeftThumbstickLeft || e.OriginalKey == VirtualKey.GamepadLeftThumbstickRight)
            {
                e.Handled = true;
                return;
            }

            //Manejo del foco de los dos botones que estan en la pagina principal
            switch (e.OriginalKey)
            {
                case VirtualKey.Up:
                case VirtualKey.GamepadDPadUp:
                    // el candidato es el primer objeto al navegar hacia abajo en la lista 
                    candidate = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Up);
                    // movemos el foco al siguiente objeto
                    if (candidate == null)
                        candidate = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Previous);

                    (candidate as Control).Focus(FocusState.Keyboard);
                    e.Handled = true;
                    break;
                case VirtualKey.Down:
                case VirtualKey.GamepadDPadDown:
                    // el candidato es el primer objeto al navegar hacia abajo en la lista
                    candidate = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Down);
                    // movemos el foco al siguiente objeto
                    if (candidate == null)
                        candidate = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Next);

                    //Casteamos el Objeto que guarda el cambio de foco a un control para establecer eso como foco en focusmanager
                    (candidate as Control).Focus(FocusState.Keyboard);
                    e.Handled = true;
                    break;

                case VirtualKey.Left:
                case VirtualKey.GamepadDPadLeft:
                    // el candidato es el primer objeto al navegar hacia abajo en la lista 
                    candidate = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Left);
                    // movemos el foco al siguiente objeto

                    if (candidate != null)
                        (candidate as Control).Focus(FocusState.Keyboard);
                    e.Handled = true;
                    break;
                case VirtualKey.Right:
                case VirtualKey.GamepadDPadRight:
                    // el candidato es el primer objeto al navegar hacia abajo en la lista
                    candidate = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Right);
                    // movemos el foco al siguiente objeto

                    //Casteamos el Objeto que guarda el cambio de foco a un control para establecer eso como foco en focusmanager
                    if (candidate != null)
                        (candidate as Control).Focus(FocusState.Keyboard);
                    e.Handled = true;
                    break;
            }

        }
    }
}
