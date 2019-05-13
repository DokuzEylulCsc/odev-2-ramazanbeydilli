using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class OgretimElemanlari
    {
        protected string adsoyad;
        protected Bolum bolum;
        protected int telefon = 000;

        public OgretimElemanlari(string adsoyad, Bolum bolum)
        {
            this.adsoyad = adsoyad;
            this.bolum = bolum;
        }
        public string ogretimadi
        {
            get
            {
                return adsoyad;
            }

        }
        public string bolumadi
        {
            get
            {
                return bolum.isim;
            }
        }
    }
}
