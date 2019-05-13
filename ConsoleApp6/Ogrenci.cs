using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Ogrenci
    {
        protected int numara;
        protected string adsoyad;
        protected Bolum bolum;
        protected int telefon = 000;

        public Ogrenci(int numara, string adsoyad, Bolum bolum)
        {
            this.numara = numara;
            this.adsoyad = adsoyad;
            this.bolum = bolum;
        }
        public string ogradi
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
        public int ogrno
        {
            get
            {
                return numara;
            }
        }
    }
}
