using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
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

        int index = -1;
        int indexDios = -1;

        object draggedItem;

        MediaPlayer song;

        //PARA MUERTES
        long DEATHS = 0;
        int incomingKills = 0;
        public PagPrincipal()
        {
            this.InitializeComponent();


            //Activar sonido
            ElementSoundPlayer.State = ElementSoundPlayerState.On;
            //Activar musica
            song = new MediaPlayer();
        }
        private async void playSong()
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("song.mp3");
            song.Source = MediaSource.CreateFromStorageFile(file);
            song.Volume = 0.1f;
            song.AutoPlay = true;
        }
        void changeMusicVolume(object sender, RoutedEventArgs e)
        {
            Slider w = sender as Slider;
            if (song != null)
                song.Volume = w.Value / 500;
        }

        void changeFXVolume(object sender, RoutedEventArgs e)
        {
            Slider w = sender as Slider;
            if (song != null)
                ElementSoundPlayer.Volume = w.Value / 100;
        }

        public ObservableCollection<VMCatastrofe> ListaCatastrofes { get; } = new ObservableCollection<VMCatastrofe>();
        public ObservableCollection<VMMejora> ListaMejoras { get; } = new ObservableCollection<VMMejora>();
        public ObservableCollection<VMDios> ListaDioses { get; } = new ObservableCollection<VMDios>();
        public ObservableCollection<VMDios> ListaPanteon { get; } = new ObservableCollection<VMDios>();



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            playSong();
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

            if (ListaMejoras != null)
                foreach (Mejora mejora in MejoraModel.GetAllMejoras())
                {
                    VMMejora vMMejora = new VMMejora(mejora);
                    ListaMejoras.Add(vMMejora);
                }

            if (ListaDioses != null)
                foreach (Dios dios in ModelDios.GetAllDioses())
                {
                    VMDios VMDios = new VMDios(dios);
                    ListaDioses.Add(VMDios);
                }
            
            if (ListaPanteon != null)
                foreach (Dios dios in ModelDios.GetAllPanteones())
                {
                    VMDios VMDios = new VMDios(dios);
                    ListaPanteon.Add(VMDios);
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
            SOULS += soulsPerClick;
            soulText.Text = SOULS.ToString() + " ALMAS";

            if (DEATHS < 7000000000)
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
            song.Pause();
            //Application.Current.Exit();
        }

        private void noExit_Click(object sender, RoutedEventArgs e)
        {
            exitPopUp.IsOpen = false;
        }


        private void enterConfig_Click(object sender, RoutedEventArgs e)
        {
            configPopUp.IsOpen = true;
        }

        private void exitConfig_Click(object sender, RoutedEventArgs e)
        {
            configPopUp.IsOpen = false;
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
            UpdateIndex();

        }

        private void UpdateIndex()
        {
            index = -1;
        }

        //Updatea las almas 
        private void UpdateSouls()
        {
            SOULS += soulsPerSecond;
            soulText.Text = SOULS.ToString() + " ALMAS";
        }

        #region sound
        private void soundToggle_Toggled(object sender, RoutedEventArgs e)
        {
            if (soundToggle.IsOn == true)
            {
                ElementSoundPlayer.State = ElementSoundPlayerState.On;
                if (song != null)
                    song.Play();
            }
            else
            {
                if (song != null)
                    song.Pause();
                ElementSoundPlayer.State = ElementSoundPlayerState.Off;
                ElementSoundPlayer.SpatialAudioMode = ElementSpatialAudioMode.Off;
            }
        }
        #endregion

        private void Catastrofe_Click(object sender, RoutedEventArgs e)
        {
            CList.IsEnabled = false;
            Mapa.IsEnabled = true;
        }

        private void Mapa_Click(object sender, RoutedEventArgs e)
        {
            CList.IsEnabled = true;
            Mapa.IsEnabled = false;

            if (DEATHS < 7000000000)
            {
                incomingKills = 1000000;
                DEATHS += incomingKills;
                deathBarText.Text = DEATHS.ToString() + "/7000000000";
                deathBar.Value = DEATHS * 100 / 7000000000;
            }
        }

        private void ItemGridView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)

        {
            draggedItem = e.Items[0];
            
        }



        private async void ItemGridView2_Drop(object sender, DragEventArgs e)

        {

            string data = await e.Data.GetView().GetTextAsync("data");



            //Find the position where item will be dropped in the gridview

            Point pos = e.GetPosition(panteon.ItemsPanelRoot);



            //Get the size of one of the gridview items

            GridViewItem viewItem = (GridViewItem)panteon.ContainerFromIndex(0);



            double itemHeight = viewItem.ActualHeight + viewItem.Margin.Top + viewItem.Margin.Bottom;

            double itemWidth = viewItem.ActualWidth + viewItem.Margin.Left + viewItem.Margin.Right;



            //Determine the index of the item from the item position (assumed all items are the same size)

            int index = Math.Min(panteon.Items.Count - 1, (int)(pos.Y / itemHeight) * 4 + (int)(pos.X / itemWidth));



            var item = panteon.Items[index];

            item = data;

        }

        private void panteon_DragOver(object sender, DragEventArgs e)
        {
            //Find the position where item will be dropped in the gridview

            Point pos = e.GetPosition(panteon.ItemsPanelRoot);



            //Get the size of one of the gridview items

            GridViewItem viewItem = (GridViewItem)panteon.ContainerFromIndex(0);



            double itemHeight = viewItem.ActualHeight + viewItem.Margin.Top + viewItem.Margin.Bottom;

            double itemWidth = viewItem.ActualWidth + viewItem.Margin.Left + viewItem.Margin.Right;



            //Determine the index of the item from the item position (assumed all items are the same size)

            index = Math.Min(panteon.Items.Count - 1, (int)(pos.Y / itemHeight) * 4 + (int)(pos.X / itemWidth));


            //ponerlo, okay ahora quiero ahcerlo solamente cuando suelte el drag, problema, el puto dragDrop no funciona >:c no funciona
            
        }

        private void panteon_DropCompleted(UIElement sender, DropCompletedEventArgs args)
        {
            ListaPanteon[index] = (draggedItem as VMDios);
        }

        private void panteon_Drop(object sender, DragEventArgs e)
        {

            ListaPanteon[index] = (draggedItem as VMDios);
        }

        private void panteon_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            //if (index >= 0)
            //{
            //    ListaPanteon[index] = (draggedItem as VMDios);
            //    index = -1;
            //}
        }

        private void panteon_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            //if (index >= 0)
            //{
            //    ListaPanteon[index] = (draggedItem as VMDios);
            //    index = -1;
            //}
        }

        private void ContentGridView_DropCompleted(UIElement sender, DropCompletedEventArgs args)
        {
            //if (index >= 0)
            //{
            //    ListaPanteon[index] = (draggedItem as VMDios);
            //    index = -1;
            //}
        }

        private void ContentGridView_DragLeave(object sender, DragEventArgs e)
        {
            //if (index >= 0)
            //{
            //    ListaPanteon[index] = (draggedItem as VMDios);
            //    index = -1;
            //}
        }

        private void ContentGridView_DragItemsCompleted(ListViewBase sender, DragItemsCompletedEventArgs args)
        {
            if (index >= 0)
            {
                VMDios aux = ListaPanteon[index];
                ListaPanteon[index] = (draggedItem as VMDios);
                ListaDioses.Remove(draggedItem as VMDios);
                index = -1;
                if (aux.Id != -1)
                {
                    ListaDioses.Add(aux);
                }
            }
        }


        private void panteon_DragLeave(object sender, DragEventArgs e)
        {
            index = -1;
        }

        private void panteon_FocusDisengaged(Control sender, FocusDisengagedEventArgs args)
        {
            index = -1;
        }
    }
}
