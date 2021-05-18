using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class PagPrincipal : Page
    {
        int SOULS;
        public PagPrincipal()
        {
            this.InitializeComponent();
        }
        public ObservableCollection<VMCatastrofe> ListaCatastrofes { get; } = new ObservableCollection<VMCatastrofe>();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            SharedShadow.Receivers.Add(purpleRect);
            SharedShadow.Receivers.Add(hadesBack);



            soul.Translation += new System.Numerics.Vector3(0, 0, 32);
            auxRectSoul.Translation += new System.Numerics.Vector3(0, 0, 32);
            cerbero.Translation += new System.Numerics.Vector3(0, 0, 32);

            //soul.Rotation = 45;

            SOULS = 0;
            soulText.Text = SOULS.ToString() + " ALMAS";

            //Mueves los rectángulos hacia delante 

            if (ListaCatastrofes != null) // Carga la lista de ModelView
                foreach (Catastrofe catastrofe in Model.GetAllCatastrofes())
                {
                    VMCatastrofe VMitem = new VMCatastrofe(catastrofe);
                    ListaCatastrofes.Add(VMitem);
                }
            //Control de la vuelta atras
            if (this.Frame.CanGoBack)
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            else
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            base.OnNavigatedTo(e);
        }

        #region goBack 
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }
        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }
        #endregion
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void soul_Click(object sender, RoutedEventArgs e)
        {
            SOULS++;
            soulText.Text = SOULS.ToString() + 1000 + " ALMAS";
        }
    }
}
