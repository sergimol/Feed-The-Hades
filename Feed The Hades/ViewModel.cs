using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Feed_The_Hades
{
    public class VMCatastrofe : Catastrofe
    {
        public Image Img;
        public ContentControl CCImg;
        public int Zoom;
        public VMCatastrofe(Catastrofe dron)
        {
            Id = dron.Id;
            Nombre = dron.Nombre;
            Imagen = dron.Imagen;
            Precio = dron.Precio;
            PrecioText = dron.PrecioText;
            Kills = dron.Kills;
            Img = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + dron.Imagen;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            Img.Width = 50;
            Img.Height = 50;
            CCImg = new ContentControl();
            CCImg.Content = Img;
            CCImg.UseSystemFocusVisuals = true;
            //CCImg.Visibility = Windows.UI.Xaml.Visibility.Visible;//.Collapsed;
            //Mapa.Children.Add(CCImg);
            //Mapa.Children.Last().SetValue(Canvas.LeftProperty, X - 25);
            //Mapa.Children.Last().SetValue(Canvas.TopProperty, Y - 25);
        }

    }

    public class VMDios : Dios
    {
        public VMDios(Dios d)
        {
            Id = d.Id;
            Nombre = d.Nombre;
            Imagen = d.Imagen;
        }
    }


    public class VMMejora : Mejora
    {
        public VMMejora(Mejora m)
        {
            iconGlyph = m.iconGlyph;
            level = m.level;
            text = m.text;
            fontSize = m.fontSize;
            isEnabled = m.isEnabled;
            iconMargin = m.iconMargin;
            levelMargin = m.levelMargin;
            name = m.name;
            precio = m.precio;
        }
    }
}
