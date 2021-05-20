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

        //Timer para el update del juego
        DispatcherTimer UpdateTimer;

        //PARA ALMAS
        int SOULS;
        int soulsPerSecond = 100;
        int soulsPerClick = 10;

        //PARA MUERTES
        long DEATHS = 0;
        int incomingKills = 0;
        public PagPrincipal()
        {
            this.InitializeComponent();
        }
        public ObservableCollection<VMCatastrofe> ListaCatastrofes { get; } = new ObservableCollection<VMCatastrofe>();
        public ObservableCollection<VMMejora> ListaMejoras { get; } = new ObservableCollection<VMMejora>();



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            //SharedShadow.Receivers.Add(purpleRect);
            //SharedShadow.Receivers.Add(hadesBack);



            soul.Translation += new System.Numerics.Vector3(0, 0, 32);
            auxRectSoul.Translation += new System.Numerics.Vector3(0, 0, 32);
            //cerbero.Translation += new System.Numerics.Vector3(0, 0, 32);

            //soul.Rotation = 45;

            SOULS = 0;
            DEATHS = 0;
            soulText.Text = SOULS.ToString() + " ALMAS";
            deathBarText.Text = 0 + "/7000000000";
            deathBar.Value = 0;


            //Mueves los rectángulos hacia delante 

            if (ListaCatastrofes != null) // Carga la lista de ModelView
                foreach (Catastrofe catastrofe in Model.GetAllCatastrofes())
                {
                    VMCatastrofe VMitem = new VMCatastrofe(catastrofe);
                    ListaCatastrofes.Add(VMitem);
                }

            if(ListaMejoras != null)
                foreach (Mejora mejora in MejoraModel.GetAllMejoras())
                {
                    VMMejora vMMejora = new VMMejora(mejora);
                    ListaMejoras.Add(vMMejora);
                }

            //Control de la vuelta atras
            if (this.Frame.CanGoBack)
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            else
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            base.OnNavigatedTo(e);

            UpdateTimerSetup();
        }

        //#region goBack 
        //private void Back_Click(object sender, RoutedEventArgs e)
        //{
        //    On_BackRequested();
        //}
        //private bool On_BackRequested()
        //{
        //    if (this.Frame.CanGoBack)
        //    {
        //        this.Frame.GoBack();
        //        return true;
        //    }
        //    return false;
        //}
        //#endregion
        #region Buttons
        //Click config
        //private void configButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Page2));
        //}
        //Click exit
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            exitPopUp.IsOpen = true;
        }
        private void soul_Click(object sender, RoutedEventArgs e)
        {
            SOULS+=soulsPerClick;
            soulText.Text = SOULS.ToString() + " ALMAS";

            if(DEATHS < 7000000000)
            {
                incomingKills = 100000000;
                DEATHS += incomingKills;
                deathBarText.Text = DEATHS.ToString() + "/7000000000";
                deathBar.Value = DEATHS * 100 / 7000000000;
            }
            

            
        }

        private void Mejora_Click(object sender, RoutedEventArgs e)
        {
            StackPanel content = (StackPanel)(sender as Button).Content;
            UIElementCollection elements = content.Children;
            TextBlock box = (TextBlock)elements[2];
            string s = box.Text;
            int i = int.Parse(s);
            i++;
            box.Text = i.ToString();
        }
        #endregion

        private void shop_Click(object sender, RoutedEventArgs e)
        {
            shopPopUp.IsOpen = true;
        }

        private void confirmExit_Click(object sender, RoutedEventArgs e)
        {
            //carga la pagina 2 y ademas pasa el dato del nombre
            this.Frame.Navigate(typeof(Javi));
            //Application.Current.Exit();
        }

        private void noExit_Click(object sender, RoutedEventArgs e)
        {
            exitPopUp.IsOpen = false;
        }

        //Timer para la actualizacion del juego
        public void UpdateTimerSetup()
        {
            //Configurar la actualizacion del timer para 1cs de segundo
            UpdateTimer = new DispatcherTimer();
            UpdateTimer.Tick += UpdateTimer_Tick; //Funcion de callback cada vez que se completa el timer
            UpdateTimer.Interval = new TimeSpan(10000000); // por segundo
            UpdateTimer.Start();
        }

        //Callback cada vez que se tiene que actualizar el juego
        private void UpdateTimer_Tick(object sender, object e)
        {
            UpdateSouls();

        }

        //Updatea las almas 
        private void UpdateSouls()
        {
            SOULS += soulsPerSecond;
            soulText.Text = SOULS.ToString() +  " ALMAS";
        }
    }
}
