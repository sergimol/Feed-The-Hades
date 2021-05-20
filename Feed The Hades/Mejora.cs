using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_The_Hades
{
    public class Mejora
    {
        public string iconGlyph { get; set; }
        public int level { get; set; }
        public string precio { get; set; }
        public string text { get; set; }
        public int fontSize { get; set; }
        public bool isEnabled { get; set; }
        public string iconMargin { get; set; }
        public string levelMargin { get; set; }
        public string name { get; set; }

        public Mejora() { }
    }

    public class MejoraModel
    {
        public static List<Mejora> Mejoras = new List<Mejora>()
        {
            new Mejora()
            {
                iconGlyph = "\uED56",
                level = 0,
                text = "Comida de Cerbero",
                fontSize = 25,
                isEnabled = true,
                iconMargin = "0,0,45,0",
                levelMargin = "50,0,0,0",
                name = "cerbero",
                precio = "1000 Almas"
            },
            new Mejora()
            {
                iconGlyph = "\uEA92",
                level = 0,
                text = "Hijos de Tánatos",
                fontSize = 25,
                isEnabled = true,
                iconMargin = "0,0,50,0",
                levelMargin = "90,0,0,0",
                name = "tanatos",
                precio = "5000 Almas"
            },
            new Mejora()
            {
                iconGlyph = "\uEB48",
                level = 0,
                text = "Puertos de Caronte",
                fontSize = 25,
                isEnabled = true,
                iconMargin = "0,0,50,0",
                levelMargin = "50,0,0,0",
                name = "caronte",
                precio = "50000 Almas"
            },
            new Mejora()
            {
                iconGlyph = "\uE825",
                level = 0,
                text = "Bancos de Almas",
                fontSize = 25,
                isEnabled = true,
                iconMargin = "0,0,45,0",
                levelMargin = "80,0,0,0",
                name = "bancos",
                precio = "100000 Almas"
            }
        };

        public static IList<Mejora> GetAllMejoras()
        {
            return Mejoras;
        }

        public static Mejora GetMejoraById(int id)
        {
            return Mejoras[id];
        }
    }

}
