using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Feed_The_Hades
{
    public class Catastrofe
    {
        public enum estados { Desbloqueado, NoDesbloqueado, Disponible, NoDisponible };

        public int Id { get; set; }

        public long Precio { get; set; }

        public long Kills { get; set; }
        public string Nombre { get; set; }
        public string PrecioText { get; set; }
        public string Imagen { get; set; }
        public Brush borderbrush { get; set; }
        public Brush backgroundBrush { get; set; }
        //public Image Img;

        public Catastrofe() { }
    }




    public class Model
    {
        public static List<Catastrofe> Catastrofes = new List<Catastrofe>()
        {
        new Catastrofe()
        {
            Id = 0,
            Nombre = "Terremoto",
            Imagen = "Assets\\TIRRA.png",
            Precio = 10000,
            PrecioText = "10 000 Almas",
            Kills = 10000000,
            borderbrush = new SolidColorBrush(Color.FromArgb(255, 255,165,0)), //naranja
            backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 160,70,0))
    },
        new Catastrofe()
        {
            Id = 1,
            Nombre = "Tsunami",
            Imagen = "Assets\\TIRRA.png",
            Precio = 25000,
            PrecioText = "25 000 Almas",
            Kills = 1000000,
            borderbrush = new SolidColorBrush(Color.FromArgb(255, 255,165,0)), //naranja
            backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 160,70,0))
            },
        new Catastrofe()
        {
            Id = 2,
            Nombre = "Invocar Gigante",
            Imagen = "Assets\\TIRRA.png",
            Precio = 50000,
            PrecioText = "50 000 Almas",
            Kills = 2000000,
            borderbrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0)), //Amarillo
            backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 160, 160, 0))
            },
            new Catastrofe()
        {
            Id = 2,
            Nombre = "Guerra",
            Imagen = "Assets\\TIRRA.png",
            Precio = 1000000,
            PrecioText = "1M Almas",
            Kills = 50000000,
            borderbrush = new SolidColorBrush(Color.FromArgb(255, 255,0,0)), //ROJO
            backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 160,0,0))
            },new Catastrofe()
        {
            Id = 3,
            Nombre = "Erupcion Volcanica",
            Imagen = "Assets\\TIRRA.png",
            Precio = 2000000,
            PrecioText = "2M Almas",
            Kills = 12000000,
            borderbrush = new SolidColorBrush(Color.FromArgb(255, 255,165,0)), //naranja
            backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 160,70,0))
            },
            new Catastrofe()
        {
            Id = 2,
            Nombre = "Invocar Hecatonquiro",
            Imagen = "Assets\\TIRRA.png",
            Precio = 5000000,
            PrecioText = "5M Almas",
            Kills = 100000000,
            borderbrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0)), //Amarillo
            backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 160, 160, 0))
            },

            new Catastrofe()
        {
            Id = 4,
            Nombre = "Guerra Fria",
            Imagen = "Assets\\TIRRA.png",
            Precio = 10000000,
            PrecioText = "10M Almas",
            Kills = 500000000,
            borderbrush = new SolidColorBrush(Color.FromArgb(255, 255,0,0)), //ROJO
            backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 160,0,0))
            },new Catastrofe()

        {
            Id = 5,
            Nombre = "Cabeza Nuclear",
            Imagen = "Assets\\TIRRA.png",
            Precio = 100000000,
            PrecioText = "100M Almas",
            Kills = 50000000000,
            borderbrush = new SolidColorBrush(Color.FromArgb(255, 255,0,0)), //ROJO
            backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 160,0,0))
            },
            new Catastrofe()

        {
            Id = 5,
            Nombre = "Fragmento Lunar",
            Imagen = "Assets\\TIRRA.png",
            Precio = 100000000,
            PrecioText = "1000M Almas",
            Kills = 100000000000,
            borderbrush = new SolidColorBrush(Color.FromArgb(255, 255,165,0)), //naranja
            backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 160,70,0))
            },
            new Catastrofe()

        {
            Id = 6,
            Nombre = "Bomba de Hidrogeno",
            Imagen = "Assets\\TIRRA.png",
            Precio = 10000000000,
            PrecioText = "10000M Almas",
            Kills = 100000000000,
            borderbrush = new SolidColorBrush(Color.FromArgb(255, 255,0,0)), //ROJO
            backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 160,0,0))
            },new Catastrofe()

        {
            Id = 2,
             Nombre = "Brecha hacia el Hades",
            Imagen = "Assets\\TIRRA.png",
            Precio = 70000000000,
            PrecioText = "70000M Almas",
            Kills = 700000000000,
            borderbrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0)), //Amarillo
            backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 160, 160, 0))
            },

        };
        public static IList<Catastrofe> GetAllCatastrofes()
        {
            return Catastrofes;
        }
        public static Catastrofe GetCatastrofeById(int id)
        {
            return Catastrofes[id];
        }


    }


    public class Dios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }

    }

    public class ModelDios
    {
        public static List<Dios> Dioses = new List<Dios>()
        {
            new Dios()
            {
                Id = 0,
                Nombre = "Apollo",
                Imagen = "/Assets/eltio.png",
            },new Dios()
            {
                Id = 1,
                Nombre = "Apollo",
                Imagen = "/Assets/alexcalvo.png",
            },new Dios()
            {
                Id = 2,
                Nombre = "Apollo",
                Imagen = "/Assets/eltio.png",
            },new Dios()
            {
                Id = 3,
                Nombre = "Apollo",
                Imagen = "/Assets/eltio.png",
            }
        };


        public static List<Dios> Panteon = new List<Dios>()
        {
            new Dios()
            {
                Id = -1,
                Nombre = "Apollo",
                Imagen = "/Assets/leomesi.png",
            },new Dios()
            {
                Id = -1,
                Nombre = "Apollo",
                Imagen = "/Assets/leomesi.png",
            },new Dios()
            {
                Id = -1,
                Nombre = "Apollo",
                Imagen = "/Assets/leomesi.png",
            }
        };


        public static IList<Dios> GetAllDioses()
        {
            return Dioses;
        }
        public static Dios GetDiosById(int id)
        {
            return Dioses[id];
        }

        public static IList<Dios> GetAllPanteones()
        {
            return Panteon;
        }
        public static Dios GetPanteonById(int id)
        {
            return Panteon[id];
        }

        public static Dios DiosTemplateVacio()
        {
            return new Dios()
            {
                Id = -1,
                Nombre = "Apollo",
                Imagen = "/Assets/leomesi.png",
            };
        }

    }



}


