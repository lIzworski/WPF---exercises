using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Edycja_Produktów
{
    internal class Produkt
    {
        public Produkt() { }

        public string Symbol { get; set; }
        public string Nazwa { get; set; }
        public int LiczbaSztuk { get; set; }
        public string Magazyn { get; set; }


        
        public Uri Zdjecie { get; set; }

        public Produkt(string symbol, string nazwa, int liczbaSztuk, string magazyn, Uri zdjecie)
        {
            Symbol = symbol;
            Nazwa = nazwa;
            LiczbaSztuk = liczbaSztuk;
            Magazyn = magazyn;
            Zdjecie = zdjecie;
        }

        public override string ToString()
        {
            return String.Format($"{Symbol} {Nazwa} {LiczbaSztuk} {Magazyn}");
        }
    }
}
