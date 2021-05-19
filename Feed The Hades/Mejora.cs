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
        public string text { get; set; }
        public int fontSize { get; set; }
        public bool isEnabled { get; set; }
        public string iconMargin { get; set; }
        public string levelMargin { get; set; }

        public Mejora() { }
    }

    public class MejoraModel
    {
        public static List<Mejora> Mejoras = new List<Mejora>()
        {
            new Mejora()
            {
                iconGlyph = "\uED56",
                level = 12,
                text = "Comida de Cerbero",
                fontSize = 25,
                isEnabled = true,
                iconMargin = "0,0,45,0",
                levelMargin = "50,0,0,0"
            },
            new Mejora()
            {
                iconGlyph = "\uEA92",
                level = 7,
                text = "Hijos de Tánatos",
                fontSize = 25,
                isEnabled = true,
                iconMargin = "0,0,50,0",
                levelMargin = "90,0,0,0"
            },
            new Mejora()
            {
                iconGlyph = "\uEB48",
                level = 2,
                text = "Puertos de Caronte",
                fontSize = 25,
                isEnabled = true,
                iconMargin = "0,0,50,0",
                levelMargin = "50,0,0,0"
            },
            new Mejora()
            {
                iconGlyph = "\uE825",
                level = 0,
                text = "Bancos de Almas",
                fontSize = 25,
                isEnabled = false,
                iconMargin = "0,0,45,0",
                levelMargin = "80,0,0,0"
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
