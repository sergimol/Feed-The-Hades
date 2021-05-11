using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_The_Hades
{
    public class Catastrofe
    {
        public enum estados { Desbloqueado, NoDesbloqueado, Disponible, NoDisponible };

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        //public Image Img;
        public string Explicacion { get; set; }
        public estados Estado { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int RX;
        public int RY;

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
            Explicacion = @"Explicación Dron1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
            Estado = Catastrofe.estados.Desbloqueado,
            X = 10,
            Y = 10,
            RX =100,
            RY =30,
            },
        new Catastrofe()
        {
            Id = 1,
            Nombre = "Tsunami",
            Imagen = "Assets\\TIRRA.png",
            Explicacion = @"Explicación Dron1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
            Estado = Catastrofe.estados.Desbloqueado,
            X = 10,
            Y = 10,
            RX =100,
            RY =30,
            },
            new Catastrofe()
        {
            Id = 2,
            Nombre = "Guerra",
            Imagen = "Assets\\TIRRA.png",
            Explicacion = @"Explicación Dron1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
            Estado = Catastrofe.estados.Desbloqueado,
            X = 10,
            Y = 10,
            RX =100,
            RY =30,
            }

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
}


