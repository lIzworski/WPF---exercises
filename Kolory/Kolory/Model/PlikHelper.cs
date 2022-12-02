using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kolory.Model
{
    public static class PlikHelper
    {
        public const string nazwaPliku = "ustawienia.txt";
        public static void Zapisz(this ModelMPAM model)
        {

            string łańcuch = model.Wartosc.ToString();
            File.WriteAllText(nazwaPliku, łańcuch);
        }

        public static ModelMPAM Odczyt()
        {
            try
            {
                string łańcuch = File.ReadAllText(nazwaPliku);
                double wartosc = double.Parse(łańcuch);
                return new ModelMPAM() { Wartosc = wartosc };

            }
            catch
            {
                return new ModelMPAM() { Wartosc = 0 };
            }
        }
    }
}
