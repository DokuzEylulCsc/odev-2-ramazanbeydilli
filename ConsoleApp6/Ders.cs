using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Ders
    {
        int donem;
        OgretimElemanlari ogrt; 
        private string ad;
        Bolum b;
        public Ders(string ad, Bolum b, int donem) 
        {
            this.ad = ad;
            this.b = b;
            this.donem = donem;
        }
        public string isim
        {
            get { return ad; }

        }
        public Bolum bol
        {
            get { return b; }
        }
        public OgretimElemanlari eleman 
        {
            get { return ogrt; }
            set { ogrt = value; }
        }
        public List<Sube> subesi = new List<Sube>(); 
        public List<Ogrenci> ogrencis = new List<Ogrenci>(); 

    }
}
