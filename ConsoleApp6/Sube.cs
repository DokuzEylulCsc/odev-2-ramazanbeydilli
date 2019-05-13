using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Sube
    {
        private string ad;
        Ders d;
        public Sube(string ad, Ders d)
        {
            this.ad = ad;
            this.d = d;
        }
        public string isim
        {
            get { return ad; }

        }
        public Ders dd
        {
            get { return d; }
        }
        List<Ogrenci> ogrenciss = new List<Ogrenci>();
    }
}
